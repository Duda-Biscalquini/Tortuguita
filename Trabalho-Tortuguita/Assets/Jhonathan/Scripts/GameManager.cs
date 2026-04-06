using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    public void AddPoints(int points)
    {
        score += points;
        if (scoreText != null) scoreText.text = score.ToString();
    }
}