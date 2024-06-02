using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class KeyController : MonoBehaviour
    {
        //  public bool meme1Door = false;
        //  public bool meme1Key = false;
        
        // private Pickup pickups;

        public bool ShopMushroomKey = false;
        public bool ShopPotionKey = false;



        private InteractController ic;

        private void Start()
        {
            ic = GetComponent<InteractController>();
            
        }

        public void ObjectInteraction()
        {
            // if (memeDoor)
            // {
            //     doorObject.PlayAnimation();
            // }
        
            // else if (memeKey)
            // {
            //     _keyInventory.hasmemeKey = true;
            //     gameObject.SetActive(false);
            // }


        }
    }
