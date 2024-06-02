using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryInspectInti : MonoBehaviour
{
    [Header("Kanan")]
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI namaInti;
    [SerializeField] private TextMeshProUGUI overviewInti;


 
    private DataInti dataInti;
    private DataRamuan dataRamuan;
    private DataKristal dataKristal;

    public void Init(DataInti data)
    {
        dataInti = data;

        iconImage.sprite = dataInti.gambar_2d;
        namaInti.text = dataInti.nama_inti;
        overviewInti.text = dataInti.overview_inti;
    }

    public void Tini(DataRamuan data)
    {
        dataRamuan = data;
        iconImage.sprite = dataRamuan.gambar_2d;
        namaInti.text = dataRamuan.nama_ramuan;
        overviewInti.text = dataRamuan.overview_ramuan;
    }

    public void Niti(DataKristal data)
    {
        dataKristal = data;
        iconImage.sprite = dataKristal.gambar_2d;
        namaInti.text = dataKristal.nama_kristal;
        overviewInti.text = dataKristal.overview_kristal;
    }

}
