using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootsProjectiles : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShootsProjectile(AnvilProjectileDNA dna)
    {
        GameObject new_projectile = (GameObject)Resources.Load("Prefabs/Anvil Projectile");

        new_projectile.GetComponent<AnvilProjectileDNA>().projectile_DNA = dna.projectile_DNA;

        Instantiate(new_projectile);

        new_projectile.GetComponent<AnvilProjectileDestructionData>().how_many_seconds_it_should_exist =
            dna.projectile_DNA[(int)Support.ProjectileDNANames.PROJECTILE_TIME];
    }
}
