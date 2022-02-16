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


    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = "�ְ� ���� : " + bestScore;
    }

    public void SetScore(int value)
    {
        currentScore = value;
        currentTextUI.text = "���� ���� : " + currentScore;

        if(currentScore > bestScore)
        {
            bestScore = currentScore;
            bestScoreUI.text = "�ְ� ���� : " + bestScore;
            PlayerPrefs.SetInt("Best Score", bestScore);
        }
    }

    public int GetScore()
    {
        return currentScore;
    }
}
