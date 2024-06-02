using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static DataRamuan;

public class CrafterManagerRamuan : MonoBehaviour
{
    public static CrafterManagerRamuan Instance;
    // public List<Item> Items = new List<Item>();
    public Inventory inventory;

    public List<CrafterItemRamuan> DRamuan = new List<CrafterItemRamuan>();

    public Transform ItemContent;
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

    // public void Adinventory.DRamuan(DataRamuan ramuan)
    // {
    //     if (ramuan.jumlah_ramuan > 0 && !inventory.DRamuan.Contains(ramuan))
    //     {
    //         inventory.DRamuan.Add(ramuan);
    //     }
    //     else
    //     {
    //         inventory.DRamuan[inventory.DRamuan.IndexOf(ramuan)].jumlah_ramuan += 1;
    //     }
    
    // }

    // public void AddJamur(DataRamuan ramuan, int Qty)
    // {
    //     if (ramuan.jumlah_ramuan > 0 && !inventory.DRamuan.Contains(ramuan))
    //     {
    //         inventory.DRamuan.Add(ramuan);
    //     }
    //     else
    //     {
    //         inventory.DRamuan[inventory.DRamuan.IndexOf(ramuan)].jumlah_ramuan += Qty;
    //     }
    // }

    // public void RemoveJamur(DataRamuan ramuan)
    // {
    //     inventory.DRamuan.Remove(ramuan);
    // }

    public void InventoryRamuan()
    {
        foreach (Transform ramuan in ItemContent)
        {
            Destroy(ramuan.gameObject);
        }
        foreach (var ramuan in DRamuan)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            obj.GetComponent<CrafterItemRamuanGO>().DR = ramuan.dataRamuan;

            obj.GetComponent<Button>().onClick.AddListener(() =>
            {
                ShopPanel.SetActive(true);
                var objInspect = GameObject.Find("CraftInspectBiasa").GetComponent<CrafterInspectRamuan>();
                objInspect.Init(ramuan);
            });
            
            var NamaJamur = obj.transform.Find("title").GetComponent<TextMeshProUGUI>();
            var JamurIcon = obj.transform.Find("icon").GetComponent<Image>();
            var Coin = obj.transform.Find("harga").GetComponent<TextMeshProUGUI>();

            
            JamurIcon.sprite = ramuan.dataRamuan.gambar_2d;
            NamaJamur.text = ramuan.dataRamuan.nama_ramuan;
            Coin.text = ramuan.makePrice.ToString();
        }
    }
    
}
