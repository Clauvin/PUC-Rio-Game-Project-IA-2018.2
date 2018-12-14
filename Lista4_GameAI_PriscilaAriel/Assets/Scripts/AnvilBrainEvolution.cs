using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilBrainEvolution : MonoBehaviour {

    public float plus_randomization_change;
    public int max_or_min;
    public float max_value_to_add;

    public AnvilProjectileDNA MutateNewDNA()
    {
        float random_result = Random.Range(0, 1);
        if (random_result <= 0.5f)
        {
            return AddValueToDNA();
        }
        else
        {
            return SwapValues();
        }
    }

    AnvilProjectileDNA AddValueToDNA()
    {
        float random_result = Random.Range(0, 1);
        if (random_result <= plus_randomization_change)
        {
            max_or_min = 1;
        }
        else
        {
            max_or_min = -1;
        }

        random_result = Random.Range(0, max_value_to_add);

        float value_to_add = random_result;
        value_to_add *= max_or_min;

        random_result = Random.Range(0, 14);
        if (random_result > 13) random_result = 13;

        int wheres_the_best_dna = GetComponent<AnvilBrainResults>().best_dna;

        AnvilProjectileDNA new_dna = (AnvilProjectileDNA)
            GetComponent<AnvilBrainResults>().dnas[wheres_the_best_dna];

        new_dna.projectile_DNA[(int)random_result] += value_to_add;

        return new_dna;
    }

    AnvilProjectileDNA SwapValues()
    {
        float position_1;
        float position_2;

        position_1 = Random.Range(0, 14);
        if (position_1 > 13) position_1 = 13;

        do
        {
            position_2 = Random.Range(0, 14);
            if (position_1 > 13) position_1 = 13;
        } while ((int)position_1 == (int)position_2);

        AnvilProjectileDNA new_dna = (AnvilProjectileDNA)
            GetComponent<AnvilBrainResults>().dnas[GetComponent<AnvilBrainResults>().best_dna];

        float change = new_dna.projectile_DNA[(int)position_1];
        new_dna.projectile_DNA[(int)position_1] = new_dna.projectile_DNA[(int)position_2];
        new_dna.projectile_DNA[(int)position_2] = change;

        return new_dna;

    }

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
