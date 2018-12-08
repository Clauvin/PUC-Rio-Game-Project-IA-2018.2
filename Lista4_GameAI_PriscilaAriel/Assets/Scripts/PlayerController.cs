using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Private variables
    private Animator anim;
    private float moveZ;
    private float moveX;

    private int hash;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Moving the character with arrow keys
        moveZ = Input.GetAxis("Vertical");
        moveX = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", moveZ);
        anim.SetFloat("Turn", moveX);

        // Attack
        if (Input.GetKeyDown("space"))
            anim.SetTrigger("Attack");
    }
}
