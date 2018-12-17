using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilProjectileFitness : MonoBehaviour {

    GameObject player;

    void StoreNewFitness()
    {
        float new_fitness;

        Vector3 player_position = player.transform.position;
        Vector3 projectile_position = this.transform.position;

        new_fitness = Mathf.Pow(player_position.x - projectile_position.x, 2) +
                        Mathf.Pow(player_position.y - projectile_position.y, 2) +
                        Mathf.Pow(player_position.z - projectile_position.z, 2);

        new_fitness = Mathf.Sqrt(new_fitness);

        if (new_fitness < GetComponent<AnvilProjectileFitnessData>().fitness){
            GetComponent<AnvilProjectileFitnessData>().fitness = new_fitness;
        }
    }

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        StoreNewFitness();
	}
}
