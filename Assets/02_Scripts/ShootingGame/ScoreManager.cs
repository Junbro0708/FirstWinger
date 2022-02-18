using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text currentTextUI;
    private int currentScore;

    public Text bestScoreUI;
    private int bestScore;

    public static ScoreManager Instance = null;

    public int Score // 프로퍼티 get set
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value;
            currentTextUI.text = "현재 점수 : " + currentScore;

            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                bestScoreUI.text = "최고 점수 : " + bestScore;
                PlayerPrefs.SetInt("Best Score", bestScore);
            }
        }
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }


    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = "최고 점수 : " + bestScore;
    }
}
