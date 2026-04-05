using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecttible : MonoBehaviour
{
    public int points = 1;
    public float rotationSpeed = 100f;
    public ScoreManager gameManager;
    // Update is called once per frame
    void Update()
    {
        RotateObject();
    }

    void RotateObject()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddPoint();
            Destroy(gameObject);
        }
    }

}
