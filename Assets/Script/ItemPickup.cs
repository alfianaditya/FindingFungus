using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    InventoryManagerJamur inventoryManagerJamur;
    public DataJamur Djamur;

    public GameObject BtnInteract;

    public void Start()
    {
        Djamur = GetComponent<ItemController>().DJ;
    }

    public void Pickup()
    {
        inventoryManagerJamur = InventoryManagerJamur.Instance;
        inventoryManagerJamur.AddJamur(Djamur, 1);
        //destroy then add to inventory
        Destroy(gameObject);   
    }

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
