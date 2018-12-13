using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilProjectileDNA : MonoBehaviour {

    public float[] projectile_DNA;

    enum ProjectileDNANames
    {
        PROJECTILE_SPEED,
        X_SIZE,
        Y_SIZE,
        Z_SIZE,
        X_OFFSET,
        Y_OFFSET,
        Z_OFFSET,
        X_EXTRA_ACCELERATION,
        Y_EXTRA_ACCELERATION,
        Z_EXTRA_ACCELERATION,
        X_TELEGUIDING,
        Y_TELEGUIDING,
        Z_TELEGUIDING
    }

    AnvilProjectileDNA(float[] projectile_DNA)
    {
        this.projectile_DNA = projectile_DNA;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
