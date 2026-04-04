using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerCollector : MonoBehaviour

{
    public GameManager gameManager;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            CollatingTa collectible =
                other.GetComponent<CollatingTa>();

            if (collectible != null)
            {
                gameManager.AddPoint(collectible.point);
             }

            Destroy(other.gameObject);

        }
    }
    
}
