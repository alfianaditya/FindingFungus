using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CrafterInspectRamuan : MonoBehaviour
{
    [Header("Bahan Jamur")]
    [SerializeField] private Image iconJamur;
    [SerializeField] private TextMeshProUGUI punyaJamur;
    [SerializeField] private TextMeshProUGUI butuhJamur;

    [Space(20)]
    [Header("Bahan Inti")]
    [SerializeField] private Image iconInti;

    [SerializeField] private TextMeshProUGUI punyaInti;
    [SerializeField] private TextMeshProUGUI butuhInti;

    [Space(20)]
    [Header("kanan")]
    [SerializeField] private TextMeshProUGUI namaRamuan;
    [SerializeField] private TextMeshProUGUI statusRamuan;
    [SerializeField] private TextMeshProUGUI makePriceRamuan;
    



    [Space(20)]
    [Header("Validasi Buat")]
    
    [SerializeField] private GameObject validasibuat;
    [SerializeField] private Image iconJamurvalidasibuat;
    [SerializeField] private TextMeshProUGUI punyaJamurvalidasibuat;
    [SerializeField] private TextMeshProUGUI butuhJamurvalidasibuat;
    
    [Space(20)]
    [SerializeField] private Image iconIntivalidasibuat;
    [SerializeField] private TextMeshProUGUI punyaIntivalidasibuat;
    [SerializeField] private TextMeshProUGUI butuhIntivalidasibuat;
    [SerializeField] private TextMeshProUGUI coinvalidasibuat;
    [SerializeField] private Button makeBtn;


    [Space(20)]
    [Header("Validasi Bahan Kurang")]

    [SerializeField] private GameObject validasibahankurang;
    [SerializeField] private Image iconJamurVBahankurang;
    [SerializeField] private TextMeshProUGUI punyaJamurVBahankurang;
    [SerializeField] private TextMeshProUGUI butuhJamurVBahankurang;

    [Space(20)]
    [SerializeField] private Image iconIntiVBahankurang;
    [SerializeField] private TextMeshProUGUI punyaIntiVBahankurang;
    [SerializeField] private TextMeshProUGUI butuhIntiVBahankurang;

    [Space(20)]
    [Header("Validasi Koin Kurang")]
    [SerializeField] private GameObject validasikoinkurang;

    [Space(20)]
    [Header("Validasi Setelah Buat")]
    [SerializeField] private GameObject afterbuat;
    [SerializeField] private Image iconRamuanAfterBuat;
    [SerializeField] private TextMeshProUGUI namaRamuanAfterBuat;


    private CrafterItemRamuan crafterItemRamuan;
    private DataRamuan dataRamuan;
    private DataInti dataInti;
    private DataJamur dataJamur;
    public void Init(CrafterItemRamuan data)
    {
        dataRamuan = data.dataRamuan;

        //Bahan Jamur Bawah
        iconJamur.sprite = data.requiredJamur.Item.gambar_2d;
        punyaJamur.text = data.requiredJamur.Item.jumlah_jamur.ToString();
        butuhJamur.text = data.requiredJamur.Amount.ToString();

        //make text color to red if the player doesn't have enough jamur
        if (data.requiredJamur.Item.jumlah_jamur < data.requiredJamur.Amount)
        {
            punyaJamur.color = Color.red;
        }
        else {
            punyaJamur.color = new Color(0.1529f, 0.3765f, 0.3490f, 255f);
        }

        //Bahan Inti Bawah
        iconInti.sprite = data.requiredInti.Item.gambar_2d;
        punyaInti.text = data.requiredInti.Item.jumlah_inti.ToString();
        butuhInti.text = data.requiredInti.Amount.ToString();

        //make text color to red if the player doesn't have enough inti
        if (data.requiredInti.Item.jumlah_inti < data.requiredInti.Amount)
        {
            punyaInti.color = Color.red;
        }
        else
        {
            punyaInti.color = new Color(0.1529f, 0.3765f, 0.3490f, 255f);
        }

        //Info Inspector
        namaRamuan.text = data.dataRamuan.nama_ramuan;
        statusRamuan.text = data.dataRamuan.text_status_ramuan;
        makePriceRamuan.text = data.makePrice.ToString();

        //Validasi Buat
        iconJamurvalidasibuat.sprite = data.requiredJamur.Item.gambar_2d;
        punyaJamurvalidasibuat.text = data.requiredJamur.Item.jumlah_jamur.ToString();
        butuhJamurvalidasibuat.text = data.requiredJamur.Amount.ToString();
        iconIntivalidasibuat.sprite = data.requiredInti.Item.gambar_2d;
        punyaIntivalidasibuat.text = data.requiredInti.Item.jumlah_inti.ToString();
        butuhIntivalidasibuat.text = data.requiredInti.Amount.ToString();
        coinvalidasibuat.text = data.makePrice.ToString();
        
        //make text color to red if the player doesn't have enough jamur in validasi buat
        if (data.requiredJamur.Item.jumlah_jamur < data.requiredJamur.Amount)
        {
            punyaJamurvalidasibuat.color = Color.red;
        }
        else
        {
            punyaJamurvalidasibuat.color = new Color(0.1529f, 0.3765f, 0.3490f, 255f);
        }

        //make text color to red if the player doesn't have enough inti in validasi buat
        if (data.requiredInti.Item.jumlah_inti < data.requiredInti.Amount)
        {
            punyaIntivalidasibuat.color = Color.red;
        }
        else
        {
            punyaIntivalidasibuat.color = new Color(0.1529f, 0.3765f, 0.3490f, 255f);
        }


        //Validasi Bahan Kurang
        iconJamurVBahankurang.sprite = data.requiredJamur.Item.gambar_2d;
        punyaJamurVBahankurang.text = data.requiredJamur.Item.jumlah_jamur.ToString();
        butuhJamurVBahankurang.text = data.requiredJamur.Amount.ToString();
        iconIntiVBahankurang.sprite = data.requiredInti.Item.gambar_2d;
        punyaIntiVBahankurang.text = data.requiredInti.Item.jumlah_inti.ToString();
        butuhIntiVBahankurang.text = data.requiredInti.Amount.ToString();

        //make text color to red if the player doesn't have enough Jamur in validasi bahan kurang
        if (data.requiredJamur.Item.jumlah_jamur < data.requiredJamur.Amount)
        {
            punyaJamurVBahankurang.color = Color.red;
        }
        else
        {
            punyaJamurVBahankurang.color = new Color(0.1529f, 0.3765f, 0.3490f, 255f);
        }
        //make text color to red if the player doesn't have enough Inti in validasi bahan kurang
        if (data.requiredInti.Item.jumlah_inti < data.requiredInti.Amount)
        {
            punyaIntiVBahankurang.color = Color.red;
        }
        else
        {
            punyaIntiVBahankurang.color = new Color(0.1529f, 0.3765f, 0.3490f, 255f);
        }

        //Validasi Setelah Buat
        iconRamuanAfterBuat.sprite = data.dataRamuan.gambar_2d;
        namaRamuanAfterBuat.text = data.dataRamuan.nama_ramuan;
        
        makeBtn.onClick.RemoveAllListeners();

        makeBtn.onClick.AddListener(() =>
        {
            if(data.requiredJamur.Item.jumlah_jamur < data.requiredJamur.Amount || data.requiredInti.Item.jumlah_inti < data.requiredInti.Amount)
            {
                validasibuat.SetActive(false);
                validasibahankurang.SetActive(true);
                Debug.Log("bahan kurang");
            }
            else if(Coinmanager.Instance.GetCoin() < data.makePrice)
            {
                validasibuat.SetActive(false);
                validasikoinkurang.SetActive(true);
                Debug.Log("koin kurang");
            }
            else
            {
                validasibuat.SetActive(false);
                afterbuat.SetActive(true);
                Coinmanager.Instance.ReduceCoin(data.makePrice);
                InventoryManagerJamur.Instance.RemoveJamur(data.requiredJamur.Item, data.requiredJamur.Amount);
                InventoryManagerInti.Instance.RemoveInti(data.requiredInti.Item, data.requiredInti.Amount);
                InventoryManagerRamuan.Instance.AddRamuan(data.dataRamuan, 1);
                Debug.Log("berhasil dibuatt");

            }
        });

    }


}
