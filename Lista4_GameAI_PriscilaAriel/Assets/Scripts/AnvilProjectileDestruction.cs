using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilProjectileDestruction : MonoBehaviour {

    AnvilProjectileDestructionData data;
    AnvilBrainOrders brain_orders;

    private bool destroy_in_next_frame = false;

    bool TimeToDestroy()
    {
        if (Time.time > data.time_of_creation + data.how_many_seconds_it_should_exist)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

	// Use this for initialization
	void Start () {
        data = GetComponent<AnvilProjectileDestructionData>();
        brain_orders = GameObject.FindGameObjectWithTag("Anvil Brain").GetComponent<AnvilBrainOrders>();
        data.time_of_creation = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (TimeToDestroy() && !destroy_in_next_frame)
        {
            destroy_in_next_frame = true;
        } else if (TimeToDestroy() && destroy_in_next_frame)
        {
            brain_orders.number_of_projectiles_travelling--;
            Destroy(gameObject);
        }
	}
}
