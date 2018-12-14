using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilProjectileSynapsis : MonoBehaviour {

    AnvilBrainResults brain_results;

    void PassResultsToBrain()
    {
        brain_results.dnas.Add(GetComponent<AnvilProjectileDNA>());
        brain_results.fitness_data.Add(GetComponent<AnvilProjectileFitnessData>());

        if (brain_results.dnas.Count == 1)
        {
            brain_results.best_dna = 0;
            brain_results.best_fitness = GetComponent<AnvilProjectileFitnessData>().fitness;
        } else
        {
            if (brain_results.best_fitness > GetComponent<AnvilProjectileFitnessData>().fitness)
            {
                brain_results.best_dna = brain_results.dnas.Count - 1;
                brain_results.best_fitness = GetComponent<AnvilProjectileFitnessData>().fitness;
            }
        }
    }

	// Use this for initialization
	void Start () {
        brain_results = GameObject.FindGameObjectWithTag("Anvil Brain").GetComponent<AnvilBrainResults>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
