using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    public GameManager gameManager;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collecttible"))
        {
            Collecttible collectible = other.GetComponent<Collecttible>();

            if (collectible != null)
            {
                gameManager.AddPoints(collectible.points);
            }

            Destroy(other.gameObject);
        }
 
    
    
    }

    

       
          
    }



