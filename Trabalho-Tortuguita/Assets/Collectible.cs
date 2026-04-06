using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectible : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddPoint();
                Destroy(other.gameObject);
            }
            else
            {
                Debug.LogError("O ScoreManager não foi encontrado");
            }
        }
    }
}