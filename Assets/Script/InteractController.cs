using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class InteractController : MonoBehaviour
    {
        [Header("Interactable NPC")]
        // ui tulisan shop diatas

        public GameObject UI_interaction;
        public GameObject btn_interaction;

        // private bool doorOpen = false;


        // [SerializeField] private int timeToShowUI = 1;
        // [SerializeField] private GameObject showDoorLockedUI = null;
        private KeyInventory _keyInventory = null;
        // [SerializeField] private Score scorse;

        [SerializeField] private int waitTimer = 1;
        [SerializeField] private bool pauseInteraction = false;

        private void Awake()
        {
            // doorAnim = gameObject.GetComponent<Animator>();
        }

        private IEnumerator PauseDoorInteraction()
        {
            pauseInteraction = true;
            yield return new WaitForSeconds(waitTimer);
            pauseInteraction = false;
        }

        public void Interact()
        {
            if(_keyInventory.hasShopPotionKey==true){
                dosomething();
            }
            else if(_keyInventory.hasShopMushroomKey==true){
                dosomething();
            }
            else{
                // StartCoroutine(showDoorLocked());
                System.Console.WriteLine("kunci tidak ada");
            }
        }

        public void dosomething()
        {
            if(!pauseInteraction)
                {
                    UI_interaction.SetActive(true);
                    btn_interaction.SetActive(true);
                    StartCoroutine(PauseDoorInteraction());
                }
        }

        public void btn_on()
        {
            btn_interaction.SetActive(true);
        }

        public void btn_off()
        {
            btn_interaction.SetActive(false);
        }
        // public IEnumerator showDoorLocked()
        // {
        //     showDoorLockedUI.SetActive(true);
        //     yield return new WaitForSeconds(timeToShowUI);
        //     showDoorLockedUI.SetActive(false);
        // }


    }

