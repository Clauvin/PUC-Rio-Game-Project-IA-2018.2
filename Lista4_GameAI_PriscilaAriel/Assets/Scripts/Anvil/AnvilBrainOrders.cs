using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilBrainOrders : MonoBehaviour {

    AnvilBrainEvolution brain_evolution;
    AnvilBrainResults brain_results;

    public int number_of_projectiles_travelling;

    public GameObject[] anvil_shooters;

	// Use this for initialization
	void Start () {
        brain_evolution = GetComponent<AnvilBrainEvolution>();
        brain_results = GetComponent<AnvilBrainResults>();
        number_of_projectiles_travelling = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (number_of_projectiles_travelling <= 0)
        {
            number_of_projectiles_travelling = 0;
            brain_results.ChooseBestDNAandFitness();

            for (int i = 0; i < anvil_shooters.Length; i++)
            {
                if (GetComponent<AnvilBrainResults>().best_fitness > 2)
                {
                    anvil_shooters[i].GetComponent<ShootsProjectiles>().ShootsProjectile(brain_evolution.MutateNewDNA());
                } else
                {
                    anvil_shooters[i].GetComponent<ShootsProjectiles>().ShootsProjectile(
                        GetComponent<AnvilBrainResults>().best_dna);
                }

                number_of_projectiles_travelling++;
            }

            brain_results.TrimLists();
        }
	}
}
