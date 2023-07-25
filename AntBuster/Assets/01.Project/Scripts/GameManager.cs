using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{

    public static GameManager instance; // 싱글톤을 할당할 전역 변수
    //public bool isSteal = false; //
    public TMP_Text scoreText;
    private bool isGameOver = default;
    private float score = 0f; // 게임 점수
    //private int food = 0; 
    public GameObject pauseMenu = default;
    //private bool isStop = default;
    //private float surviveTime = default;
    void Awake()
    {
        // 싱글톤 변수 instance가 비어있는가?
        if (instance == null)
        {
            // instance가 비어있다면(null) 그곳에 자기 자신을 할당
            instance = this;
        }
        else
        {
            // instance에 이미 다른 GameManager 오브젝트가 할당되어 있는 경우

            // 씬에 두개 이상의 GameManager 오브젝트가 존재한다는 의미.
            // 싱글톤 오브젝트는 하나만 존재해야 하므로 자신의 게임 오브젝트를 파괴
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //isStop = false;
        isGameOver = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            // 점수를 증가
            score += 1.0f * Time.deltaTime;
            scoreText.text = string.Format("Score : {0}", (int)score);
        }

    }


    public void PauseGame()
    {
        Time.timeScale = 0;
        //isStop = true;

        pauseMenu.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;

        pauseMenu.SetActive(false);

    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("PlayScene");
    }


}
