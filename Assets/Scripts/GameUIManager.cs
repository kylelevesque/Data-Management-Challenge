using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    string currentName;
    int currentScore;

    string previousHighScorerName;
    int previousHighScore;


    public TMP_Text nameText;
    public Text highScoreText;

    MainManager mainManager;

    private void Start()
    {
        mainManager = FindObjectOfType<MainManager>().GetComponent<MainManager>();

        currentName = Manager.Instance.playerName;
        previousHighScore = Manager.Instance.highScore;
        previousHighScorerName = Manager.Instance.highScoreOwnerName;

        nameText.text = "Name: " + currentName;
        highScoreText.text = "Best Score: " + previousHighScorerName + ": " + previousHighScore;
    }

    private void Update()
    {
        currentScore = mainManager.m_Points;

        if(currentScore > previousHighScore)
        {
            Manager.Instance.highScore = currentScore;
            Manager.Instance.highScoreOwnerName = currentName;
        }
    }
}
