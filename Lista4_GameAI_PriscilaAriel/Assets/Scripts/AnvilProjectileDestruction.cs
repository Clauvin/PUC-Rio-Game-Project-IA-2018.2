﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilProjectileDestruction : MonoBehaviour {

    AnvilProjectileDestructionData data;

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
        data.time_of_creation = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (TimeToDestroy() && !destroy_in_next_frame)
        {
            //Preparativos de envio
            destroy_in_next_frame = true;
        } else if (TimeToDestroy() && destroy_in_next_frame)
        {
            Destroy(gameObject);
        }
	}
}
