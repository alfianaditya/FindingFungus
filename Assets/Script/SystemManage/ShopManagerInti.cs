using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManagerInti : MonoBehaviour
{
    public static ShopManagerInti Instance;

    public List<ShopItemInti> DInti = new List<ShopItemInti>();

    public Transform ItemContent;
    public GameObject ShopItem;
    public GameObject ShopPanel;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ShopInti();
    }


    public void ShopInti()
    {
        foreach (Transform inti in ItemContent)
        {
            Destroy(inti.gameObject);
        }
        foreach (var inti in DInti)
        {
            GameObject obj = Instantiate(ShopItem, ItemContent);
            obj.GetComponent<ShopItemIntiGO>().DI = inti.dataInti;

            obj.GetComponent<Button>().onClick.AddListener(() =>
            {
                    ShopPanel.SetActive(true);
                    var objInspect = GameObject.Find("ShopInspectIntiMonster").GetComponent<ShopInspectInti>();
                    objInspect.Init(inti);
                

            });
            
            var NamaInti = obj.transform.Find("title").GetComponent<TextMeshProUGUI>();
            var IntiIcon = obj.transform.Find("icon").GetComponent<Image>();
            var Coin = obj.transform.Find("harga").GetComponent<TextMeshProUGUI>();
            
            IntiIcon.sprite = inti.dataInti.gambar_2d;
            NamaInti.text = inti.dataInti.nama_inti;
            Coin.text = inti.sellPrice.ToString();
        }
    }

}
