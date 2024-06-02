using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    [RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(CharacterController))]
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
	[RequireComponent(typeof(PlayerInput))]
#endif

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    //for variable player
    public float fullHealth;
    float currentHealth;
    public bool playerDied = false;

    //for other component of player
    // SkillAttack _controller;
    ThirdPersonController tpc;

    //for other game object
    public GameObject UI_In_Game;
    public GameObject UI_Dead;
    public Slider playerHealthSlider;

    // Awake is called before the first frame update
    void Awake()
    {
        Instance = this;
        currentHealth = fullHealth;
        playerHealthSlider.minValue = 0;
        playerHealthSlider.maxValue = fullHealth;
        playerHealthSlider.value = currentHealth;

        // _controller = GetComponent<SkillAttack>();
        tpc = GetComponent<ThirdPersonController>();

    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        
    }

    public void addDamage(float damage)
    {
        currentHealth -= damage;
        playerHealthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            playerDied = true;
            UI_In_Game.SetActive(false);
            UI_Dead.SetActive(true);
            // _controller.Death();
            tpc.enabled = false;
        }
    }
    public void Healing()
    {
        currentHealth = fullHealth;
        playerHealthSlider.value = currentHealth;
        //add health value to full health


    }
}
}
