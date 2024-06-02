using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractJamur : MonoBehaviour
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
    public void Interact()
    {
        InventoryManagerJamur.Instance.AddJamur( GetComponent<ItemController>().DJ, 1);
        Destroy(gameObject);
    }


}
