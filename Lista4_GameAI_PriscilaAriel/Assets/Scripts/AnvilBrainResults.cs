using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilBrainResults : MonoBehaviour {

    public ArrayList dnas;
    public ArrayList fitness_data;
    public int best_dna;
    public float best_fitness;

	// Use this for initialization
	void Start () {
        dnas = new ArrayList();
        fitness_data = new ArrayList();
        best_dna = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
