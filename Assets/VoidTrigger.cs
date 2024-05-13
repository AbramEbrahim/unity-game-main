
using System;
using UnityEngine;

public class VoidTrigger : MonoBehaviour
{
    public Transform respawnPoint;
    [SerializeField] private  Health Player;

	
	void OnTriggerEnter2D(Collider2D other)
    {
        if (!Player.dead)
        {

            if (other.CompareTag("Player")) 
            {
                //RespawnPlayer(other.transform);
                
                Player.TakeDamage(10000);
                Time.timeScale = 0f;
            }
        }
    }

    void RespawnPlayer(Transform playerTransform)
    {
        playerTransform.position = respawnPoint.position;
        
    }
}
