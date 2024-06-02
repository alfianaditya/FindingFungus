using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    

public class InventoryInspectRamuan : MonoBehaviour
{

    [Header("Kanan")]
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI namaRamuan;
    [SerializeField] private TextMeshProUGUI overviewRamuan;
    [SerializeField] private TextMeshProUGUI statusRamuan;

    //how to connect to script PlayerHealth and why still missing reference
    // public GameObject playerHealth;
    private DataRamuan dataRamuan;

    // void Start()
    // {
    //     playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    // }

    public void Init(DataRamuan data)
    {
        dataRamuan = data;
        iconImage.sprite = dataRamuan.gambar_2d;
        namaRamuan.text = dataRamuan.nama_ramuan;
        overviewRamuan.text = dataRamuan.overview_ramuan;
        statusRamuan.text = dataRamuan.text_status_ramuan;
    }

    public void Inita(DataRamuan data)
    {
        dataRamuan = data;
        //use ramuan -1 jumlah ramuan
        dataRamuan.jumlah_ramuan -= 1;
        // playerHealth.currentHealth += dataRamuan.heal_amount;

    }



}
