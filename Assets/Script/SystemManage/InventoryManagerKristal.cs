using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static DataKristal;

public class InventoryManagerKristal : MonoBehaviour
{
    public static InventoryManagerKristal Instance;
    // public List<Item> Items = new List<Item>();
    public Inventory inventory;

    public Transform ItemContent;
    public GameObject InventoryItem;
    public GameObject ShopPanel;



    

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InventoryKristal();
    }

    void Update()
    {

    }

    public void AddKristal(DataKristal kristal, int Qty)
    {
        if (kristal.jumlah_kristal > 0 && !inventory.DKristal.Contains(kristal))
        {
            inventory.DKristal.Add(kristal);
        }
        else
        {
            inventory.DKristal[inventory.DKristal.IndexOf(kristal)].jumlah_kristal += Qty;
        }
    }

    public void RemoveKristal(DataKristal kristal)
    {
        inventory.DKristal.Remove(kristal);
    }

    public void InventoryKristal()
    {
        foreach (Transform kristal in ItemContent)
        {
            Destroy(kristal.gameObject);
        }
        foreach (var kristal in inventory.DKristal)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            obj.GetComponent<InventoryItemKristalGO>().DK = kristal;

            obj.GetComponent<Button>().onClick.AddListener(() =>
            {
                ShopPanel.SetActive(true);
                var objInspect = GameObject.Find("InventoryInspectInti").GetComponent<InventoryInspectInti>();
                objInspect.Niti(kristal);
            });
            
            var NamaInti = obj.transform.Find("title").GetComponent<TextMeshProUGUI>();
            var IntiIcon = obj.transform.Find("icon").GetComponent<Image>();
            

            
            IntiIcon.sprite = kristal.gambar_2d;
            NamaInti.text = kristal.nama_kristal;
        }
    }
    
}
