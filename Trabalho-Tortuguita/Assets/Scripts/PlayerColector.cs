using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColector : MonoBehaviour
{
    public GameManager gameManager;

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collectible"))
        {
            Collectible collectible = other.GetComponent<Collectible>(); 
            
            if(collectible != null)
            {
                gameManager.AddPoints(collectible.points);
            }

            Destroy(other.gameObject);
        }
    }

    
}
