using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //To get Canvas
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    [RequireComponent(typeof(Animator))]
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED

#endif
public class EnemyHealth : MonoBehaviour
{


    //for variables 
    public float fullHealth;
    public float currentHealth;
    public bool enemyDied = false;



    //for local components


    //for global component and other gameobject

    public Canvas enemyCanvas;
    public Slider enemyHealthSlider;
    private EnemyController enemyControll;

    itemdrop itemd;

    // Awake is called before the first frame update
    void Awake()
    {
        
        currentHealth = fullHealth;
        enemyHealthSlider.minValue = 0;
        enemyHealthSlider.maxValue = fullHealth;
        enemyHealthSlider.value = currentHealth;

        enemyControll = GetComponent<EnemyController>();


    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        
    }

    public void addDamage(float damage)
    {
        currentHealth -= damage;
        enemyHealthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            enemyDied = true;
            // enemyCanvas.enable = false;
            MakeDied();
        }
    }

    public void MakeDied()
    {
        enemyControll.Death();
        Destroy(gameObject, 3f);
    }

    
}
}