using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Support;

public class AnvilBrainResults : MonoBehaviour {

    public ArrayList dnas;
    public ArrayList fitness_data;
    public int best_dna;
    public float best_fitness;

    public void TrimLists()
    {
        AnvilProjectileDNA dna = (AnvilProjectileDNA)dnas[best_dna];
        float fitness = best_fitness;

        dnas = new ArrayList(1);
        dnas.Add(dna);
        best_dna = 0;
        best_fitness = fitness;
    }

    // Use this for initialization
    void Awake()
    {
        best_dna = 0;
        best_fitness = Mathf.Infinity;
    }

    void Start () {
        dnas = new ArrayList(1);
        fitness_data = new ArrayList(1);


        float[] valores = new float[14];
        valores[(int)ProjectileDNANames.PROJECTILE_TIME] = 6.0f;
        valores[(int)ProjectileDNANames.PROJECTILE_SPEED] = 5;
        valores[(int)ProjectileDNANames.X_EXTRA_ACCELERATION] = 0;
        valores[(int)ProjectileDNANames.X_OFFSET] = 0;
        valores[(int)ProjectileDNANames.X_SIZE] = 2;
        valores[(int)ProjectileDNANames.X_TELEGUIDING] = 0;
        valores[(int)ProjectileDNANames.Y_EXTRA_ACCELERATION] = 0;
        valores[(int)ProjectileDNANames.Y_OFFSET] = 0;
        valores[(int)ProjectileDNANames.Y_SIZE] = 2;
        valores[(int)ProjectileDNANames.Y_TELEGUIDING] = 0;
        valores[(int)ProjectileDNANames.Z_EXTRA_ACCELERATION] = 0;
        valores[(int)ProjectileDNANames.Z_OFFSET] = 0;
        valores[(int)ProjectileDNANames.Z_SIZE] = 2;
        valores[(int)ProjectileDNANames.Z_TELEGUIDING] = 0;

        AnvilProjectileDNA starter_dna = new AnvilProjectileDNA(valores);

        dnas.Add(starter_dna);
        fitness_data.Add(new AnvilProjectileFitnessData());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
