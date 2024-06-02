using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static DataJamur;

public class InventoryManagerJamur : MonoBehaviour
{
    public static InventoryManagerJamur Instance;
    ItemPickup itemPickup;
    public Inventory inventory;

    public Transform ItemContent;
    public GameObject InventoryItem;
    public GameObject ShopPanel;

    public GameObject btnCollect;



    public Action OnInventoryChange;

    public void CallOnInventoryChange()
    {
        OnInventoryChange?.Invoke();        
    }


    

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InventoryJamurs();
    }

    void OnEnable()
    {
        OnInventoryChange += InventoryJamurs;
    }

    void OnDisable()
    {
        OnInventoryChange -= InventoryJamurs;
    }


    public void AddJamur(DataJamur jamur, int Qty)
    {
        if (jamur.jumlah_jamur > 0)
        {
            Debug.Log("masuk if");

            inventory.DJamur[inventory.DJamur.IndexOf(jamur)].jumlah_jamur += Qty;
        }
        else
        {
            Debug.Log("masuk else");
            inventory.DJamur.Add(jamur);
            inventory.DJamur[inventory.DJamur.IndexOf(jamur)].jumlah_jamur += Qty;
        }
        InventoryManagerJamur.Instance.CallOnInventoryChange();
        BookManager.Instance.AddBook(jamur);
    }

    public void AddJamurs(DataJamur jamur)
    {
        if (jamur.jumlah_jamur > 0)
        {
            Debug.Log("masuk if");

            inventory.DJamur[inventory.DJamur.IndexOf(jamur)].jumlah_jamur += 1;
        }
        else
        {
            Debug.Log("masuk else");
            inventory.DJamur.Add(jamur);
            inventory.DJamur[inventory.DJamur.IndexOf(jamur)].jumlah_jamur += 1;
        }
        InventoryManagerJamur.Instance.CallOnInventoryChange();
        BookManager.Instance.AddBook(jamur);
    }

    public void ambil()
    {
        itemPickup = btnCollect.GetComponent<ItemPickup>();
        itemPickup.Pickup();
    }


    public void RemoveJamur(DataJamur jamur, int Qty)
    {
        if (jamur.jumlah_jamur > 0 )
        {
            inventory.DJamur[inventory.DJamur.IndexOf(jamur)].jumlah_jamur -= Qty;
            if (inventory.DJamur[inventory.DJamur.IndexOf(jamur)].jumlah_jamur <= 0)
            {
                inventory.DJamur.Remove(jamur);
            }
        }
    }

    public void InventoryJamurs()
    {
        foreach (Transform jamur in ItemContent)
        {
            Destroy(jamur.gameObject);
        }
        foreach (var jamur in inventory.DJamur)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            obj.GetComponent<InventoryItemJamurGO>().DJ = jamur;

            obj.GetComponent<Button>().onClick.AddListener(() =>
            {
                ShopPanel.SetActive(true);
                var objInspect = GameObject.Find("InventoryInspectJamur").GetComponent<InventoryInspectJamur>();
                objInspect.Init(jamur);
            });
            
            var NamaJamur = obj.transform.Find("title").GetComponent<TextMeshProUGUI>();
            var JamurIcon = obj.transform.Find("icon").GetComponent<Image>();
            var Qty = obj.transform.Find("Qty").GetComponent<TextMeshProUGUI>();

            
            JamurIcon.sprite = jamur.gambar_2d;
            NamaJamur.text = jamur.nama_jamur;
            Qty.text = jamur.jumlah_jamur.ToString();
        }
    }
    
    
}
