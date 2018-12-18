﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Support;

public class AnvilBrainResults : MonoBehaviour {

    public ArrayList dnas;
    public ArrayList fitness_data;

    public float[] best_dna;
    public float best_fitness = float.MaxValue;

    public int quant_of_worsening_fitness = 0;
    public int limit_of_worsening_fitness = 6;

    public void ChooseBestDNAandFitness()
    {
        float fit = float.MaxValue;
        int position = 0;

        for (int i = 0; i < dnas.Count; i++)
        {
            if (fit > ((AnvilProjectileFitnessData)fitness_data[i]).fitness)
            {
                fit = ((AnvilProjectileFitnessData)fitness_data[i]).fitness;
                position = i;
            }
        }

        Debug.Log("Fit " + fit);
        Debug.Log("Position " + position);

        if (best_dna == null)
        {
            best_dna = (float[])dnas[position];
            best_fitness = fit;
        }
        else if (best_fitness > fit)
        {
            best_dna = (float[])dnas[position];
            best_fitness = fit;
        }
        else
        {
            quant_of_worsening_fitness++;
            if (quant_of_worsening_fitness >= limit_of_worsening_fitness)
            {
                if (GetComponent<AnvilBrainEvolution>().plus_randomization_change == 1.0f)
                {
                    GetComponent<AnvilBrainEvolution>().plus_randomization_change = 0.0f;
                }
                else if (GetComponent<AnvilBrainEvolution>().plus_randomization_change == 0.0f)
                {
                    GetComponent<AnvilBrainEvolution>().plus_randomization_change = 1.0f;
                }
                quant_of_worsening_fitness = 0;
            }
        }

        Debug.Log(best_dna);
    }

    public void TrimLists()
    {
        dnas = new ArrayList(1);
        dnas.Add(best_dna);
    }

    // Use this for initialization
    void Awake()
    {

    }

    void Start () {
        dnas = new ArrayList(1);
        fitness_data = new ArrayList(1);

        float[] valores = new float[11];
        valores[(int)ProjectileDNANames.PROJECTILE_TIME] = 3.0f;
        valores[(int)ProjectileDNANames.PROJECTILE_SPEED] = 5;
        valores[(int)ProjectileDNANames.X_OFFSET] = 0;
        valores[(int)ProjectileDNANames.X_SIZE] = 2;
        valores[(int)ProjectileDNANames.X_TELEGUIDING] = 0;
        valores[(int)ProjectileDNANames.Y_OFFSET] = 0;
        valores[(int)ProjectileDNANames.Y_SIZE] = 2;
        valores[(int)ProjectileDNANames.Y_TELEGUIDING] = 0;
        valores[(int)ProjectileDNANames.Z_OFFSET] = 0;
        valores[(int)ProjectileDNANames.Z_SIZE] = 2;
        valores[(int)ProjectileDNANames.Z_TELEGUIDING] = 0;

        dnas.Add(valores);
        best_dna = valores;
        fitness_data.Add(new AnvilProjectileFitnessData());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
