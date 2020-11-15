using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMainPresenter : MonoBehaviour
{
    public ScoreViewer m_scoreViewer;
    public LimitTimeCountViewer m_limitCountViewer;

    private void Update()
    {
        if(m_limitCountViewer.m_limitTime<=0)
        {
            GoToResult();
        }
        
    }

    private void GoToResult()
    {
        if (PlayerPrefs.GetInt("HighScore",0) != 0)
        {
            if (PlayerPrefs.GetInt("HighScore") < m_scoreViewer.Score)
            {
                PlayerPrefs.SetInt("HighScore", m_scoreViewer.Score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", m_scoreViewer.Score);
        }
        SceneManager.LoadScene("Result");
        PlayerPrefs.SetInt("Score",m_scoreViewer.Score);
        PlayerPrefs.Save();
    }
}
