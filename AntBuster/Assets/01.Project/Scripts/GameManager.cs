using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{

    public static GameManager instance; // �̱����� �Ҵ��� ���� ����
    //public bool isSteal = false; //
    public TMP_Text scoreText;
    private bool isGameOver = default;
    private float score = 0f; // ���� ����
    //private int food = 0; 
    public GameObject pauseMenu = default;
    //private bool isStop = default;
    //private float surviveTime = default;
    void Awake()
    {
        // �̱��� ���� instance�� ����ִ°�?
        if (instance == null)
        {
            // instance�� ����ִٸ�(null) �װ��� �ڱ� �ڽ��� �Ҵ�
            instance = this;
        }
        else
        {
            // instance�� �̹� �ٸ� GameManager ������Ʈ�� �Ҵ�Ǿ� �ִ� ���

            // ���� �ΰ� �̻��� GameManager ������Ʈ�� �����Ѵٴ� �ǹ�.
            // �̱��� ������Ʈ�� �ϳ��� �����ؾ� �ϹǷ� �ڽ��� ���� ������Ʈ�� �ı�
            Debug.LogWarning("���� �ΰ� �̻��� ���� �Ŵ����� �����մϴ�!");
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
            // ������ ����
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
