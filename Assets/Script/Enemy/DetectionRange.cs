using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	[RequireComponent(typeof(BoxCollider))]
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED

#endif
public class DetectionRange : MonoBehaviour
{

    //for global variables
    public EnemyController enemyControll;

    // Awake is called before the first frame update
    void Awake()
    {
        
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        
    }


    //RUN
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //if player in detection range play enemy run animation

            enemyControll.Walk();
            enemyControll.playerInDetectionRange = true;
        }
    }

    //WALK
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //if player in detection range play enemy run animation

            enemyControll.Run();
            enemyControll.playerInDetectionRange = true;
        }
    }

}
}