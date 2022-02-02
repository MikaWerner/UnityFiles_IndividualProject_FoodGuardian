using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;

    void Start()
    {
        if (score == null)
        {
            scoreValue = 0;
            score = GetComponent<Text>();
        }
    }

    void Update()
    {
        score.text = "Score:" + scoreValue;
    }
}
