using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameScore : MonoBehaviour
{
    TextMeshProUGUI scoreTextUI;

    int score;
    public int Score
    {
        get { return this.score; }
        set 
        { 
            this.score = Mathf.Max(0, value);
            UpdateScoreTextUI();
        }
    }

    void Start()
    {
        scoreTextUI = GetComponent<TextMeshProUGUI>();
    }

    void UpdateScoreTextUI()
    {
        string scoreStr = string.Format("{0:0000000}" , score);
        scoreTextUI.text = scoreStr;
    }
}
