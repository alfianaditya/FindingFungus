using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BookInspect : MonoBehaviour
{
    [Header("Kiri")]
    [SerializeField] private TextMeshProUGUI namaJamur;
    [SerializeField] private Image gambarJamur2D;
    [SerializeField] private Image gambarJamur3D;
    [SerializeField] private TextMeshProUGUI binomial;
    [SerializeField] private TextMeshProUGUI kingdom;
    [SerializeField] private TextMeshProUGUI genus;
    [SerializeField] private TextMeshProUGUI famili;
    [SerializeField] private TextMeshProUGUI kelas;
    [SerializeField] private TextMeshProUGUI ordo;
    [SerializeField] private TextMeshProUGUI spesies;
    [SerializeField] private TextMeshProUGUI jenis;
    [SerializeField] private Button nextBtn;

    

    [Header("Kanan")]

    // [TextAreaAttribute]
    [SerializeField] private TextMeshProUGUI overviewJamur;
    [SerializeField] private Button prevBtn;

    int page = 1;



    void Start()
    {
        // populate data
        ShowBook(page);
    }



    public void SetData(DataJamur _dataJamur)
    {
        namaJamur.text = _dataJamur.nama_jamur;
        gambarJamur2D.sprite = _dataJamur.gambar_2d;
        gambarJamur3D.sprite = _dataJamur.gambar_3d;
        binomial.text = _dataJamur.binomial;
        kingdom.text = _dataJamur.kingdom;
        genus.text = _dataJamur.genus;
        famili.text = _dataJamur.famili;
        kelas.text = _dataJamur.kelas;
        ordo.text = _dataJamur.ordo;
        spesies.text = _dataJamur.spesies;
        jenis.text = _dataJamur.jenis;
        overviewJamur.text = _dataJamur.tentang_jamur;
    }



    public void NextBook()
    {
        if (page < BookManager.Instance.DBook.Count)
        {
            page++;
            ShowBook(page);
        }
    }



    public void PrevBook()
    {
        if (page > 1)
        {
            page--;
            ShowBook(page);
        }
    }



    public void ShowBook(int _index)
    {
        page = _index;
        DataJamur dataJamur = BookManager.Instance.GetBook(_index);
        // Debug.Log(dataJamur);
        SetData(dataJamur);
    }



     public void ShowBook(DataJamur _dataJamur)
    {
        int index = 0;
        foreach (KeyValuePair<int, DataJamur> dataJamur in BookManager.Instance.DBook)
        {
            if (dataJamur.Value == _dataJamur)
            {
                index = dataJamur.Key;
                break;
            }
        }

        if (index != 0)
            ShowBook(index);
    }
}