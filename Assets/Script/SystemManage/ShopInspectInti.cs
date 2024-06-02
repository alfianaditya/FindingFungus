using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopInspectInti : MonoBehaviour
{
    [Header("Bawah")]
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI namaInti;
    [SerializeField] private TextMeshProUGUI overviewInti;
    [SerializeField] private TextMeshProUGUI jual;


    [Space(20)]
    [Header("Validasi Jual")]
    [SerializeField] private TextMeshProUGUI titlevalidasijual;
    [SerializeField] private TextMeshProUGUI hargavalidasijual;
    [SerializeField] private GameObject validasijual;
    [SerializeField] private TextMeshProUGUI titleafterjual;
    [SerializeField] private TextMeshProUGUI hargaafterjual;
    [SerializeField] private GameObject afterjual;
    [SerializeField] private TextMeshProUGUI intikurangtext;
    [SerializeField] private GameObject intikuranglivalidasi;
    [SerializeField] private Button jualBtn;


    private ShopItemInti dataIntiShop;
    private DataInti dataInti;

    public void Init(ShopItemInti data)
    {
        dataInti = data.dataInti;

        iconImage.sprite = dataInti.gambar_2d;
        namaInti.text = dataInti.nama_inti;
        overviewInti.text = dataInti.overview_inti;
        jual.text = data.sellPrice.ToString();
        
        //Jual
        titlevalidasijual.text = "Kamu yakin ingin menjual " + dataInti.nama_inti + " seharga :";
        hargavalidasijual.text = data.sellPrice.ToString();

        //afterjual
        titleafterjual.text = "Kamu telah berhasil menjual " + dataInti.nama_inti + " dan memperoleh : ";
        hargaafterjual.text = data.sellPrice.ToString();
        
        //intikurang
        intikurangtext.text = "Kamu tidak memiliki item " + dataInti.nama_inti;
        
        

        jualBtn.onClick.RemoveAllListeners();


        jualBtn.onClick.AddListener(() =>
        {
            if (InventoryManagerInti.Instance.inventory.GetInti(dataInti) == null) {
                intikuranglivalidasi.SetActive(true);
                validasijual.SetActive(false);
                Debug.Log("Inti tidak cukup");
                return;
            }

            if(InventoryManagerInti.Instance.inventory.GetIntiCount(data.dataInti) > 0)
            {
                Coinmanager.Instance.AddCoin(data.sellPrice);
                SellItem(data);
                validasijual.SetActive(false);
                afterjual.SetActive(true);
                Debug.Log("Berhasil menjual");
            }
        });
    }


    public void SellItem(ShopItemInti dataShop)
    {
        InventoryManagerInti.Instance.RemoveInti(dataShop.dataInti, 1);
        InventoryManagerInti.Instance.CallOnInventoryChange();
    }
}
