using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilProjectileFitnessData : MonoBehaviour {

    public float fitness;

    public AnvilProjectileFitnessData() {
        fitness = Mathf.Infinity;
    }

    public AnvilProjectileFitnessData(float fitness) {
        this.fitness = fitness;
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
