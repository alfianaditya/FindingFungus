using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManagerJamur : MonoBehaviour
{
    public static ShopManagerJamur Instance;

    public List<ShopItemJamur> DJamur = new List<ShopItemJamur>();

    public Transform ItemContent;
    public GameObject ShopItem;
    public GameObject ShopPanel;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ShopJamur();
    }


    public void ShopJamur()
    {
        foreach (Transform jamur in ItemContent)
        {
            Destroy(jamur.gameObject);
        }
        foreach (var jamur in DJamur)
        {
            GameObject obj = Instantiate(ShopItem, ItemContent);
            obj.GetComponent<ShopItemJamurGO>().DJ = jamur.dataJamur;

            obj.GetComponent<Button>().onClick.AddListener(() =>
            {
                    ShopPanel.SetActive(true);
                    var objInspect = GameObject.Find("ShopInspectJamur").GetComponent<ShopInspectJamur>();
                    objInspect.Init(jamur);
                

            });
            
            var NamaJamur = obj.transform.Find("title").GetComponent<TextMeshProUGUI>();
            var JamurIcon = obj.transform.Find("icon").GetComponent<Image>();
            var Coin = obj.transform.Find("harga").GetComponent<TextMeshProUGUI>();
            
            JamurIcon.sprite = jamur.dataJamur.gambar_2d;
            NamaJamur.text = jamur.dataJamur.nama_jamur;
            Coin.text = jamur.buyPrice.ToString();
        }
    }

}
