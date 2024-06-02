using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractNpc : MonoBehaviour
{
    [SerializeField] private GameObject BtnInteract;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BtnInteract.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BtnInteract.SetActive(false);
        }
    }
}
