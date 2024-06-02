using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDropManager : MonoBehaviour
{
    public Transform itemDrop;
    public GameObject item;

    public void DropItem()
    {
        item.SetActive(true);
        Instantiate(item, itemDrop.position, itemDrop.rotation);
    }
}
