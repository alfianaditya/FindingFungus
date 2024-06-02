using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //to get navmesh agent

namespace StarterAssets
{
    [RequireComponent(typeof(Animator))]
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED

#endif
public class EnemyController : MonoBehaviour
{

    //for variables 

    //for local components

    private NavMeshAgent enemyNavMeshAgent;
    private Animator enemyAnimator;

    //for global component and other gameobject
    public Transform playerTransform;
    public bool playerInDetectionRange = false;

    public PlayerHealth pHealth;
    public GameObject detectionFight;
    public GameObject itemactive;
    public GameObject detectionRange;

    itemDropManager itemDM;

    itemdrop itemd;
    // Awake is called before the first frame update
    void Awake()
    {
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
        itemd = GetComponent<itemdrop>();
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {

        // check if player in detection range to move enemy into player

        if (playerInDetectionRange == true)
        {
            if (pHealth.playerDied == true)
            {
                enemyNavMeshAgent.transform.LookAt(playerTransform);
                Idle();
                detectionFight.SetActive(false);

            } else
            {
                enemyNavMeshAgent.SetDestination(playerTransform.position + new Vector3 (0, 0, 0.099f)); //move enemy to player
                enemyNavMeshAgent.transform.LookAt(playerTransform); //to make enemy look at player
            }
            
        }

    }

    // Start Idle Animation

    public void Idle()
    {
        enemyNavMeshAgent.speed = 0f;
        enemyAnimator.SetTrigger("Idle");
    }
    
    // End Idle Animation


    //Start Walk Animation
    public void Walk()
    {
        enemyNavMeshAgent.speed = 1f;
        enemyAnimator.SetTrigger("Walk");
    }

    //End Walk Animation

    //Start Run Animation
    public void Run()
    {
        enemyNavMeshAgent.speed = 3f;
        enemyAnimator.SetTrigger("Run");
    }

    //End Run Animation

    //Start Attack Function
    public void AttackEnemy()
    {
        enemyAnimator.SetTrigger("Attack");
    }

    //End Attack Function


    //Start Death function

    public void Death()
    {
        playerInDetectionRange = false;
        detectionRange.SetActive(false);
        enemyAnimator.SetTrigger("Death");
        detectionFight.SetActive(false);
        // itemactive.SetActive(true);
        enemyNavMeshAgent.enabled = false; 
        // itemDM.DropItem();
        
    }
}
}
