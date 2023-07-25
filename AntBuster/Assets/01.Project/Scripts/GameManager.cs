using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // �̱����� �Ҵ��� ���� ����
    //public bool isSteal = false; //

    //private int food = 0; 
    public GameObject pauseMenu = default;
    //private bool isStop = default;

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

    }


    // Update is called once per frame
    void Update()
    {
        
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
