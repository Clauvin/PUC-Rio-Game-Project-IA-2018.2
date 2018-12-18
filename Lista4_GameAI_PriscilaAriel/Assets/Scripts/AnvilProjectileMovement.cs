using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Support;

public class AnvilProjectileMovement : MonoBehaviour {

    Vector3 target_initial_position;
    Vector3 target_initial_distance;
    Vector3 target_step;

    GameObject player;

    AnvilProjectileDNA dna;

	// Use this for initialization
	void Start () {
        Vector3 scale = new Vector3(0, 0, 0);

        player = GameObject.FindGameObjectWithTag("Player");

        dna = GetComponent<AnvilProjectileDNA>();

        target_initial_position = player.transform.position;
        target_initial_distance = target_initial_position - transform.position;
        target_step = target_initial_distance / Mathf.Sqrt(target_initial_distance.x * target_initial_distance.x +
                                                   target_initial_distance.y * target_initial_distance.y +
                                                   target_initial_distance.z * target_initial_distance.z);

        scale.x = dna.projectile_DNA[(int)ProjectileDNANames.X_SIZE];
        scale.y = dna.projectile_DNA[(int)ProjectileDNANames.Y_SIZE];
        scale.z = dna.projectile_DNA[(int)ProjectileDNANames.Z_SIZE];

        transform.localScale = scale;

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 direct_change = new Vector3(0, 0, 0);
        Vector3 offset = new Vector3(0, 0, 0);
        Vector3 teleguiding = new Vector3(0, 0, 0);

        direct_change += target_step;
        direct_change *= dna.projectile_DNA[(int)ProjectileDNANames.PROJECTILE_SPEED];

        offset.x += dna.projectile_DNA[(int)ProjectileDNANames.X_OFFSET];
        offset.y += dna.projectile_DNA[(int)ProjectileDNANames.Y_OFFSET];
        offset.z += dna.projectile_DNA[(int)ProjectileDNANames.Z_OFFSET];

        if (player.transform.position.x > transform.position.x)
        {
            teleguiding.x = dna.projectile_DNA[(int)ProjectileDNANames.X_TELEGUIDING];
        }
        else if (player.transform.position.x < transform.position.x)
        {
            teleguiding.x = -1 * dna.projectile_DNA[(int)ProjectileDNANames.X_TELEGUIDING];
        }

        if (player.transform.position.y > transform.position.y)
        {
            teleguiding.y = dna.projectile_DNA[(int)ProjectileDNANames.Y_TELEGUIDING];
        }
        else if (player.transform.position.y < transform.position.y)
        {
            teleguiding.y = -1 * dna.projectile_DNA[(int)ProjectileDNANames.Y_TELEGUIDING];
        }

        if (player.transform.position.z > transform.position.z)
        {
            teleguiding.z = dna.projectile_DNA[(int)ProjectileDNANames.Z_TELEGUIDING];
        }
        else if (player.transform.position.z < transform.position.z)
        {
            teleguiding.z = -1 * dna.projectile_DNA[(int)ProjectileDNANames.Z_TELEGUIDING];
        }

        transform.position += (direct_change + offset + teleguiding) / 4;
    }
}
