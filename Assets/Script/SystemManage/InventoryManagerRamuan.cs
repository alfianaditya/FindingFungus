using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static DataRamuan;

public class InventoryManagerRamuan : MonoBehaviour
{
    public static InventoryManagerRamuan Instance;
    // public List<Item> Items = new List<Item>();
    public Inventory inventory;

    public Transform ItemContent;
    public Transform ItemContent2;
    public GameObject InventoryItem;
    public GameObject ShopPanel;



    

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InventoryRamuan();
    }

    void Update()
    {

    }

    public void AddRamuan(DataRamuan ramuan, int Qty)
    {
        if (ramuan.jumlah_ramuan > 0 && !inventory.DRamuan.Contains(ramuan))
        {
            inventory.DRamuan.Add(ramuan);
        }
        else
        {
            inventory.DRamuan[inventory.DRamuan.IndexOf(ramuan)].jumlah_ramuan += Qty;
        }
    }

    public void Removeramuan(DataRamuan ramuan)
    {
        inventory.DRamuan.Remove(ramuan);
    }

    public void InventoryRamuan()
    {
        foreach (Transform ramuan in ItemContent)
        {
            Destroy(ramuan.gameObject);
        }
        foreach (var ramuan in inventory.DRamuan)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            obj.GetComponent<InventoryItemRamuanGO>().DR = ramuan;

            obj.GetComponent<Button>().onClick.AddListener(() =>
            {
                ShopPanel.SetActive(true);
                var objInspect = GameObject.Find("InventoryInspectRamuan").GetComponent<InventoryInspectRamuan>();
                objInspect.Init(ramuan);
            });
            
            var NamaRamuan = obj.transform.Find("title").GetComponent<TextMeshProUGUI>();
            var RamuanIcon = obj.transform.Find("icon").GetComponent<Image>();
            var Qty = obj.transform.Find("Qty").GetComponent<TextMeshProUGUI>();

            
            RamuanIcon.sprite = ramuan.gambar_2d;
            NamaRamuan.text = ramuan.nama_ramuan;
            Qty.text = ramuan.jumlah_ramuan.ToString();
        }
    }
    

    public void UseRamuan()
    {
        foreach (Transform ramuan in ItemContent2)
        {
            Destroy(ramuan.gameObject);
        }
        foreach (var ramuan in inventory.DRamuan)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent2);
            obj.GetComponent<InventoryItemRamuanGO>().DR = ramuan;

            obj.GetComponent<Button>().onClick.AddListener(() =>
            {
                ShopPanel.SetActive(true);
                var objInspect = GameObject.Find("GunakanRamuan").GetComponent<InventoryInspectRamuan>();
                objInspect.Inita(ramuan);
            });
            
            
            var RamuanIcon = obj.transform.Find("icon").GetComponent<Image>();
            

            
            RamuanIcon.sprite = ramuan.gambar_2d;
        }
    }
}
