using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupinti : MonoBehaviour
{
    InventoryManagerInti inventoryManagerInti;
    public DataInti DInti;

    public GameObject BtnInteract;

    public void Start()
    {
        DInti = GetComponent<ItemControllerInti>().DI;
    }

    public void Pickup()
    {
        inventoryManagerInti = InventoryManagerInti.Instance;
        inventoryManagerInti.AddInti(DInti, 1);
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
