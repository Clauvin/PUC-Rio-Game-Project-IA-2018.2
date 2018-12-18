using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilProjectileSynapsis : MonoBehaviour {

    AnvilBrainResults brain_results;

    public void PassResultsToBrain()
    {
        brain_results.dnas.Add(GetComponent<AnvilProjectileDNA>().getProjectileDNA());
        brain_results.fitness_data.Add(GetComponent<AnvilProjectileFitnessData>());
    }

    public void PassThatAHitWasAchieved()
    {
        brain_results.a_hit_was_made = true;
    }

	// Use this for initialization
	void Start () {
        brain_results = GameObject.FindGameObjectWithTag("Anvil Brain").GetComponent<AnvilBrainResults>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
