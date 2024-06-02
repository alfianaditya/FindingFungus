using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	[RequireComponent(typeof(BoxCollider))]
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
#endif
public class EnemyDamage : MonoBehaviour
{
    //for variables 

    public float enemyDamageAmount;
    public DateTime nextDamage;
    public float damageAfterTime;
    public bool enemyInFightRange = false;
    //for local components


    //for global component and other gameobject

    public GameObject enemyObj;

    // Awake is called before the first frame update
    void Awake()
    {

        nextDamage = DateTime.Now;
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        if (enemyInFightRange == true)
        {
            DamageEnemy();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyObj = other.gameObject;
            enemyInFightRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyInFightRange = false;
        }
    }

    public void DamageEnemy()
    {
        if (nextDamage <= DateTime.Now)
        {
            if (enemyObj.GetComponent<EnemyHealth>().enemyDied == false)
            {
                enemyObj.GetComponent<EnemyHealth>().addDamage(enemyDamageAmount);
            }

            nextDamage = DateTime.Now.AddSeconds(System.Convert.ToDouble(damageAfterTime));
        }
    }
}
}