using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int score = 0;

    public void AddPoints(int value)
    {
        score += value;
        Debug.Log("Pontuação: " + score);
    }
}