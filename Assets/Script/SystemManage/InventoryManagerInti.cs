using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static DataInti;

public class InventoryManagerInti : MonoBehaviour
{
    public static InventoryManagerInti Instance;
    // public List<Item> Items = new List<Item>();
    public Inventory inventory;

    public Transform ItemContent;
    public GameObject InventoryItem;
    public GameObject ShopPanel;
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
        InventoryInti();
    }

    void OnEnable()
    {
        OnInventoryChange += InventoryInti;
    }

    void OnDisable()
    {
        OnInventoryChange -= InventoryInti;
    }

    void Update()
    {

    }

    public void AddInti(DataInti inti, int Qty)
    {
        if (inti.jumlah_inti > 0 && !inventory.DInti.Contains(inti))
        {
            inventory.DInti[inventory.DInti.IndexOf(inti)].jumlah_inti += Qty;
            
        }
        else
        {
            inventory.DInti.Add(inti);
            inventory.DInti[inventory.DInti.IndexOf(inti)].jumlah_inti += Qty;
        }
    }

    public void RemoveInti(DataInti inti, int Qty)
    {
        if (inti.jumlah_inti > 0)
        {
            inventory.DInti[inventory.DInti.IndexOf(inti)].jumlah_inti -= Qty;
            if (inventory.DInti[inventory.DInti.IndexOf(inti)].jumlah_inti <= 0)
            {
                inventory.DInti.Remove(inti);
            }
        }
    }

    public void InventoryInti()
    {
        foreach (Transform inti in ItemContent)
        {
            Destroy(inti.gameObject);
        }
        foreach (var inti in inventory.DInti)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            obj.GetComponent<InventoryItemIntiGO>().DI = inti;

            obj.GetComponent<Button>().onClick.AddListener(() =>
            {
                ShopPanel.SetActive(true);
                var objInspect = GameObject.Find("InventoryInspectInti").GetComponent<InventoryInspectInti>();
                objInspect.Init(inti);
            });
            
            var NamaInti = obj.transform.Find("title").GetComponent<TextMeshProUGUI>();
            var IntiIcon = obj.transform.Find("icon").GetComponent<Image>();
            var Qty = obj.transform.Find("Qty").GetComponent<TextMeshProUGUI>();

            
            IntiIcon.sprite = inti.gambar_2d;
            NamaInti.text = inti.nama_inti;
            Qty.text = inti.jumlah_inti.ToString();
        }
    }

    // public void GetInti
    
}
