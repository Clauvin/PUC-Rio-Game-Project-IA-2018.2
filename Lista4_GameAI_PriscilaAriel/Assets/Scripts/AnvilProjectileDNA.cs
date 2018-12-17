using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilProjectileDNA : MonoBehaviour {

    public float[] projectile_DNA;

    public AnvilProjectileDNA(float[] projectile_DNA)
    {
        this.projectile_DNA = projectile_DNA;
    }

    public float[] getProjectileDNA()
    {
        return projectile_DNA;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
