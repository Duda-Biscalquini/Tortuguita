using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0; 

    public void AddPoint(int value)
    {
        score = score + value;
    }

    
}
