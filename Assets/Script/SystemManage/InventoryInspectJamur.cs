using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryInspectJamur : MonoBehaviour
{
    [Header("Kanan")]
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI namaJamur;
    [SerializeField] private TextMeshProUGUI overviewJamur;
    [SerializeField] private Button DetailBtn;


 
    private DataJamur dataJamur;

    public void Init(DataJamur data)
    {
        dataJamur = data;

        iconImage.sprite = dataJamur.gambar_2d;
        namaJamur.text = dataJamur.nama_jamur;
        overviewJamur.text = dataJamur.overview_jamur;
        
        DetailBtn.onClick.RemoveAllListeners();

        DetailBtn.onClick.AddListener(() =>
        {

        });
    }


}
