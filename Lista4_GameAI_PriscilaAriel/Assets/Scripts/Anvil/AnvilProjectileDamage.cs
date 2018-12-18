using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilProjectileDamage : MonoBehaviour {

    GameObject player;
    PlayerHealth playerHealth;
    bool playerInRange;
    public bool damageDone;
    int damage = 10;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerInRange = false;
        damageDone = false;
    }

    void OnCollisionEnter(Collision collision)
    { 
        if (collision.collider.gameObject == player)
        {
            playerInRange = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject == player)
        {
            playerInRange = false;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playerInRange)
        {
            playerHealth.TakeDamage(damage);
            damageDone = true;
            playerInRange = false;

        }
	}
}
