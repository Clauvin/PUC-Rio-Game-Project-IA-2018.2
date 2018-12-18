using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilProjectileDestruction : MonoBehaviour {

    AnvilProjectileDestructionData data;
    AnvilBrainOrders brain_orders;

    private bool destroy_in_next_frame = false;
    public float x_limit_to_destroy = 200.0f;
    public float y_limit_to_destroy = 200.0f;
    public float z_limit_to_destroy = 200.0f;


    bool TimeToDestroy()
    {
        if ((Time.time > data.time_of_creation + data.how_many_seconds_it_should_exist) || 
                (transform.position.x > x_limit_to_destroy) || (transform.position.x * -1 > x_limit_to_destroy) ||
                (transform.position.y > y_limit_to_destroy) || (transform.position.y * -1 > y_limit_to_destroy) ||
                (transform.position.z > z_limit_to_destroy) || (transform.position.z * -1 > z_limit_to_destroy))
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
            GetComponent<AnvilProjectileSynapsis>().PassResultsToBrain();

        } else if (TimeToDestroy() && destroy_in_next_frame)
        {
            brain_orders.number_of_projectiles_travelling--;
            Destroy(gameObject);
        }
	}
}
