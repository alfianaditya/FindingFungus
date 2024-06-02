using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopInspectJamur : MonoBehaviour
{
    [Header("Bawah")]
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI namaJamur;
    [SerializeField] private TextMeshProUGUI overviewjamur;
    [SerializeField] private TextMeshProUGUI jual;
    [SerializeField] private TextMeshProUGUI beli;

    [Space(20)]
    [Header("Validasi Beli")]
    
    [SerializeField] private TextMeshProUGUI titlevalidasibeli;
    [SerializeField] private GameObject validasibeli;
    [SerializeField] private TextMeshProUGUI titleafterbeli;
    [SerializeField] private GameObject afterbeli;
    [SerializeField] private TextMeshProUGUI coinkurangtext;
    [SerializeField] private GameObject coinkurangvalidasi;
    [SerializeField] private TextMeshProUGUI hargabelivalidasi;
    [SerializeField] private Button beliBtn;

    [Space(20)]
    [Header("Validasi Jual")]
    [SerializeField] private TextMeshProUGUI titlevalidasijual;
    [SerializeField] private TextMeshProUGUI hargavalidasijual;
    [SerializeField] private GameObject validasijual;
    [SerializeField] private TextMeshProUGUI titleafterjual;
    [SerializeField] private TextMeshProUGUI hargaafterjual;
    [SerializeField] private GameObject afterjual;
    [SerializeField] private TextMeshProUGUI jamurkurangtext;
    [SerializeField] private GameObject jamurkurangvalidasi;
    [SerializeField] private TextMeshProUGUI hargajualvalidasi;
    [SerializeField] private Button jualBtn;


    private ShopItemJamur dataJamurShop;
    private DataJamur dataJamur;

    public void Init(ShopItemJamur data)
    {
        dataJamur = data.dataJamur;
        //
        iconImage.sprite = dataJamur.gambar_2d;
        namaJamur.text = dataJamur.nama_jamur;
        overviewjamur.text = dataJamur.overview_jamur;
        //
        jual.text = data.sellPrice.ToString();
        beli.text = data.buyPrice.ToString();
        //
        titlevalidasibeli.text = "Kamu yakin ingin membeli " + dataJamur.nama_jamur + " seharga :";
        coinkurangtext.text = "Koinmu tidak cukup untuk membeli " + dataJamur.nama_jamur;
        titleafterbeli.text = "Kamu berhasil membeli " + dataJamur.nama_jamur;
        hargabelivalidasi.text = data.buyPrice.ToString();
        //
        hargavalidasijual.text = data.sellPrice.ToString();
        hargaafterjual.text = data.sellPrice.ToString();
        titlevalidasijual.text = "Kamu yakin ingin menjual " + dataJamur.nama_jamur + " seharga :";
        jamurkurangtext.text = "Kamu tidak memiliki item " + dataJamur.nama_jamur;
        titleafterjual.text = "Kamu telah berhasil menjual " + dataJamur.nama_jamur + " dan memperoleh :";
        hargajualvalidasi.text = data.sellPrice.ToString();

        

        beliBtn.onClick.RemoveAllListeners();
        jualBtn.onClick.RemoveAllListeners();

        
        jualBtn.onClick.AddListener(() =>
        {
            if (InventoryManagerJamur.Instance.inventory.GetJamur(dataJamur) == null) {
                jamurkurangvalidasi.SetActive(true);
                validasijual.SetActive(false);
                Debug.Log("Jamur tidak cukup");
                return;
            }
            
            if(InventoryManagerJamur.Instance.inventory.GetJamurCount(data.dataJamur) > 0)
            {
                Coinmanager.Instance.AddCoin(data.sellPrice);
                SellItem(data);
                afterjual.SetActive(true);
                validasijual.SetActive(false);
                Debug.Log("kejual");
            }
    
        });

        beliBtn.onClick.AddListener(() =>
        {
            
            if(Coinmanager.Instance.GetCoin() >= data.buyPrice)
            {
                Coinmanager.Instance.ReduceCoin(data.buyPrice);
                BuyItem(data);
                afterbeli.SetActive(true);
                validasibeli.SetActive(false);
                Debug.Log("kebeli");
            }
            else
            {
                coinkurangvalidasi.SetActive(true);
                validasibeli.SetActive(false);
                Debug.Log("Koin tidak cukup");
            }
        });


    }
    public void BuyItem(ShopItemJamur dataShop)
    {
        InventoryManagerJamur.Instance.AddJamur(dataShop.dataJamur, 1);
        InventoryManagerJamur.Instance.CallOnInventoryChange();
    }

    public void SellItem(ShopItemJamur dataShop)
    {
        InventoryManagerJamur.Instance.RemoveJamur(dataShop.dataJamur, 1);
        InventoryManagerJamur.Instance.CallOnInventoryChange();
    }

}
