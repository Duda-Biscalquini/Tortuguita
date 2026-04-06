using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            Collectible c = other.GetComponent<Collectible>();
            if (c != null)
            {
                FindObjectOfType<GameManager>().AddPoints(c.points);
            }
            Destroy(other.gameObject);
        }
    }
}