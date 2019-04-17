using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CsUIControll : MonoBehaviour
{
    public static CsUIControll instance;

    public GameObject GO_fail;

    public GameObject GO_Score;

    public GameObject GO_BestScore;

    public GameObject GO_UnderScore;

    public GameObject ExitPanel;

    
    int score = 0;

    bool isFailActive = false;

    bool isExitButtonActive = false;

    public int level = 0;
    // Start is called before the first frame update
    private void Awake()
    {

        instance = this;
    }

    void Start()
    {
        //SaveBestScore(0);
       

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FailPannel()
    {
        if (isFailActive == false)
        {

            GO_fail.SetActive(true);

            GO_Score.GetComponent<Text>().color = Color.black;

            if (score > LoadBestScore())
            {
                SaveBestScore(score);

                GO_Score.GetComponent<Text>().color = Color.red;
            }

            GO_Score.GetComponent<Text>().text = "오늘의 급여:\n" + score + "원";

            GO_BestScore.GetComponent<Text>().text = "최고 급여:\n" + LoadBestScore() + "원";

            Time.timeScale = 0;

           
        }
        else
        {
            GO_fail.SetActive(false);
        }
    }

    public void Reset()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("InGameScene");
    }

    public void ScoreUp(int _score)
    {
        score += _score;

        GO_UnderScore.GetComponent<Text>().text = score.ToString();

    }

    public void PressExitButton()
    {
        //isExitButtonActive = !isExitButtonActive;
        //ExitPanel.SetActive(isExitButtonActive);
         if(isExitButtonActive)
        {
            Time.timeScale = 1;
            isExitButtonActive = false;
        }
         else
        {
            Time.timeScale = 0;
            isExitButtonActive = true;
        }
        ExitPanel.SetActive(isExitButtonActive);

    }
    public void GoTitle()
    {
        SceneManager.LoadScene("InGameScene");
    }
    public void SaveBestScore(int _score)
    {
        PlayerPrefs.SetInt("bestScore", _score);
    }
    public int LoadBestScore()
    {
        int num  = PlayerPrefs.GetInt("bestScore");
        return num;
    }
}
