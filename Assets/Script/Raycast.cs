using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class Raycast : MonoBehaviour
    {
        [SerializeField] private int rayLength = 5;
        [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string excluseLayerName = null;

        public InteractController shoppotion = null;
        public InteractController shopmushroom = null;

        private GameObject objectToFind_sp;
        private GameObject objectToFind_sm;


        // private KeyItemController raycastedObject;
        // [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;


        [SerializeField] private Image crosshair = null;
        private bool isCrosshairActive;
        private bool doOnce;

        private string interactableTag = "InteractiveObject";
        private string interactshoppotion = "shoppotion";
        private string interactshopmushroom = "shopmushroom";

        
        

        void Start()
        {
            objectToFind_sp = GameObject.FindGameObjectWithTag(interactshoppotion);
            shoppotion = objectToFind_sp.GetComponent<InteractController>();

            objectToFind_sm = GameObject.FindGameObjectWithTag(interactshopmushroom);
            shopmushroom = objectToFind_sm.GetComponent<InteractController>();
        }

        private void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            int mask = 1 << LayerMask.NameToLayer(excluseLayerName) | layerMaskInteract.value;

            if(Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
            {
                if(hit.collider.CompareTag(interactableTag))
                {
                    if (!doOnce)
                    {
                        CrosshairChange(true);
                    }

                    isCrosshairActive = true;
                    doOnce = true;

                }
                else if(hit.collider.CompareTag(interactshoppotion))
                {
                    if (!doOnce) 
                    {
                        CrosshairChangeShopPotion(true);
                    }

                    isCrosshairActive = true;
                    doOnce = true;

                }
                else if(hit.collider.CompareTag(interactshopmushroom))
                {
                    if (!doOnce) 
                    {
                        CrosshairChangeShopMushroom(true);
                    }

                    isCrosshairActive = true;
                    doOnce = true;

                }
            }
            else
            {
                if(isCrosshairActive)
                {
                    CrosshairChange(false);
                    CrosshairChangeShopPotion(false);
                    CrosshairChangeShopMushroom(false);
                    doOnce = false;
                }
            }
        }

        void CrosshairChange(bool on)
        {
            if(on && !doOnce)
            {
                crosshair.color = Color.red;
            }
            else
            {
                crosshair.color = Color.green;
                isCrosshairActive = false;
                
            }
        }
        void CrosshairChangeShopPotion(bool on)
        {
            if(on && !doOnce)
            {
                crosshair.color = Color.red;
                shoppotion.btn_on();
            }
            else
            {
                crosshair.color = Color.green;
                isCrosshairActive = false;
                shoppotion.btn_off();
            }
        }
        void CrosshairChangeShopMushroom(bool on)
        {
            if(on && !doOnce)
            {
                crosshair.color = Color.red;
                shopmushroom.btn_on();
            }
            else
            {
                crosshair.color = Color.green;
                isCrosshairActive = false;
                shopmushroom.btn_off();
            }
        }

    }
