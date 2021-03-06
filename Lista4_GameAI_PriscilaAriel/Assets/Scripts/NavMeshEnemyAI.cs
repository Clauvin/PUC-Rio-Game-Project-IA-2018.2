﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemyAI : MonoBehaviour {

    // Public variables
    public enum States
    {
        Idle,
        Walk,
        Attack
    }
    public States state;

    public GameObject player;
    PlayerHealth playerHealth;
    public NavMeshAgent agent;
    public float minDistanceToAttack = 1.5f;
    public float minDistanceToWalk = 20.0f;
    public float speedRotation = 1.0f;
    public float speedWalk = 1.0f;
    public int attackDamage = 10;

    //Private variables
    private Animator anim;
    private bool rotation;

    // Use this for initialization
    void Start()
    {
        state = States.Idle;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        GetComponent<NavMeshAgent>().Warp(transform.position);

        StartCoroutine(UpdateFSM());
    }

    // Update is called once per frame
    void Update()
    {
        if (state == States.Walk)
        {
            UpdateRotation(player);
            UpdatePosition();

        }

        if (state == States.Attack)
            UpdateRotation(player);
    }

    IEnumerator UpdateFSM()
    {
        while (true)
        {
            if (state == States.Idle)
            {
                if (PlayerIsVisible())
                {
                    state = States.Walk;
                    Walk();
                }

                if (PlayerIsNear())
                {
                    state = States.Attack;
                    Attack();
                }
            }
            else
            {
                if (state == States.Walk)
                {
                    if (!PlayerIsVisible())
                    {
                        state = States.Idle;
                        Idle();
                    }

                    if (PlayerIsNear())
                    {
                        state = States.Attack;
                        Attack();
                    }
                }
                else if (state == States.Attack)
                {
                    if (!PlayerIsNear())
                    {
                        state = States.Walk;
                        Walk();
                    }
                    if (!PlayerIsVisible())
                    {
                        state = States.Idle;
                        Idle();
                    }
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private bool PlayerIsNear()
    {
        Vector3 distance = transform.position - player.transform.position;
        if (distance.magnitude <= minDistanceToAttack)
            return true;
        else
            return false;
    }

    private bool PlayerIsVisible()
    {
        Vector3 distance = transform.position - player.transform.position;
        if (distance.magnitude <= minDistanceToWalk)
            return true;
        else
            return false;
    }

    private void Idle()
    {
        anim.SetBool("enemyAttack", false);
        anim.SetBool("enemyWalk", false);
    }

    private void Walk()
    {
        anim.SetBool("enemyWalk", true);
        anim.SetBool("enemyAttack", false);
    }

    private void Attack()
    {
        anim.SetBool("enemyWalk", true);
        anim.SetBool("enemyAttack", true);

        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }

    private void UpdateRotation(GameObject target)
    {
        Vector3 relativePosition = target.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(relativePosition);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * speedRotation);
    }

    private void UpdatePosition()
    {
        agent.destination = player.transform.position;
    }
}
