using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterAssets
{
    public class Dashing : MonoBehaviour
    {
        ThirdPersonController tpc;

        public float dashSpeed;
        public float dashTime;

        void Start()
        {
            tpc = GetComponent<ThirdPersonController>();
        }

        // void Update()
        // {
        //     if(Input.GetKeyDown(KeyCode.E))
        //     {
        //         StartCoroutine(Dash());
        //     }
        // }

        public void DashInput()
        {
            StartCoroutine(Dash());
        }


        IEnumerator Dash()
        {
            float startTime = Time.time;

            while(Time.time < startTime + dashTime)
            {
                tpc._controller.Move(tpc.targetDirection * dashSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
}