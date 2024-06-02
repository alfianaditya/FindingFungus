using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	[RequireComponent(typeof(SphereCollider))]
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED

#endif
public class DetectionFight : MonoBehaviour
{

    //for variables 
    public bool playerInDetectionFight = false;
    public DateTime nextDamage;
    public float fightAfterTime;


    //for local components
    public EnemyController enemyControll;
    public EnemyHealth eHealth;

    //for global component and other gameobject

    // Awake is called before the first frame update
    void Awake()
    {
        nextDamage = DateTime.Now;
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        //check id player in detection  fight to attack

        if (playerInDetectionFight == true)
        {
            FightInDetectionFight();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInDetectionFight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInDetectionFight = false;
        }
    }

    public void FightInDetectionFight()
    {
        if (nextDamage <= DateTime.Now)
        {

            if (eHealth.enemyDied == false)
            {
                enemyControll.AttackEnemy();
            }

            
            nextDamage = DateTime.Now.AddSeconds(System.Convert.ToDouble(fightAfterTime));
        }
    }


}
}
