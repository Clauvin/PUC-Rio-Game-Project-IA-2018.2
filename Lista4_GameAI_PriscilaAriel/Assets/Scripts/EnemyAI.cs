using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // Public variables
    public enum States
    {
        Idle,
        Walk,
        Attack
    }
    public States state;

    public GameObject player;
    public float minDistanceToAttack = 1.5f;
    public float minDistanceToWalk = 20.0f;
    public float speedRotation = 1.0f;
    public float speedWalk = 1.0f;

    //Private variables
    private Animator anim;
    private bool rotation;

	// Use this for initialization
	void Start ()
    {
        state = States.Idle;
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        StartCoroutine(UpdateFSM());
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (state == States.Walk)
        {
            UpdateRotation(player);
            UpdatePosition();
        }

        if (state == States.Attack)
            UpdateRotation(player);

            // Script to attack the player
            timer += Time.deltaTime;

            if(timer >= timeBetweenAttacks && playerInRange/* && enemyHealth.currentHealth > 0*/)
            {
                Attack ();
            }

            if(playerHealth.currentHealth <= 0)
            {
                //anim.SetTrigger ("PlayerDead");
            }

        // Part of Script to be able to die
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
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

        // ADDED ----- Script to make the Player lose health ----- 
        timer = 0f;

        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage);
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
        transform.position += transform.forward * Time.deltaTime * speedWalk;
    }




    // ADDED ----- Script to Attack ---------


    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;


    PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        //enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();


        // Part of Script to be able to die
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = startingHealth;
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    // ADDED ----- Script to be able to Die --------


    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    // public AudioClip deathClip;


    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;



    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        enemyAudio.Play ();

        currentHealth -= amount;
            
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger ("Dead");

        //enemyAudio.clip = deathClip;
        //enemyAudio.Play ();
    }


    public void StartSinking ()
    {
        GetComponent <NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        //ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);
    }
}
