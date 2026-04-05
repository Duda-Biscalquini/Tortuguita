using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int score = 0;
    public Text scoreText;

    public void AddPoints(int value)
    {
        score += value;
        Debug.Log("Pontuação: " + score);

        if (scoreText != null)
        {
            scoreText.text = "Pontos: " + score.ToString();
        }
    }
}