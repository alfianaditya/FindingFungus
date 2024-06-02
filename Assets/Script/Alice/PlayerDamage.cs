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
public class PlayerDamage : MonoBehaviour
{

    //for variable
    public float playerDamageAmount;
    public bool playerInRange = false;
    public DateTime nextDamage;
    public float damageAfterTime;

    //for local components

    //for global components and gameobject
    public GameObject playerObj;


    // Awake is called before the first frame update
    void Awake()
    {
        nextDamage = DateTime.Now;
        
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        if(playerInRange == true)
        {
            DamagePlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag ==  "Player")
        {
            if (other.gameObject.GetComponent<PlayerHealth>().playerDied == false)
            {
                playerObj = other.gameObject;
                playerInRange = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
        }
    }

    public void DamagePlayer()
    {
        if (nextDamage <= DateTime.Now)
        {

            if (playerObj.GetComponent<PlayerHealth>().playerDied == false)
            {
                playerObj.GetComponent<PlayerHealth>().addDamage(playerDamageAmount);
                nextDamage = DateTime.Now.AddSeconds(System.Convert.ToDouble(damageAfterTime));
            }

            
        }
    }
}
}
