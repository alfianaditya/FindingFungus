using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offsetX, offsetZ;
    [SerializeField] private float Lerpspeed;


    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, 
            new Vector3(player.position.x + offsetX, transform.position.y, player.position.z + offsetZ), Lerpspeed);
    }
}
