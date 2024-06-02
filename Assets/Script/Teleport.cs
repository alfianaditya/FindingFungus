using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterAssets
{

    public class Teleport : MonoBehaviour
    {
        public Transform player;
        public ThirdPersonController tpc;
        

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }



        public void tp_desa()
        {
            StartCoroutine(teleport_desa());
        }

        public void tp_hutan()
        {
            StartCoroutine(teleport_hutan());
        }

        IEnumerator teleport_desa()
        {
            tpc.enabled = false;
            yield return new WaitForSeconds(1);
            player.transform.position = new Vector3(10, 2, 5);
            yield return new WaitForSeconds(1);
            tpc.enabled = true;
        }

        IEnumerator teleport_hutan()
        {
            tpc.enabled = false;
            yield return new WaitForSeconds(1);
            player.transform.position = new Vector3(10, 2, -5);
            yield return new WaitForSeconds(1);
            tpc.enabled = true;
        }
    }
}