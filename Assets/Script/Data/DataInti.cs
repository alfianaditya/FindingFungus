using UnityEngine;

[CreateAssetMenu(fileName = "New Inti", menuName = "DataTable/Create Inti")]
public class DataInti : ScriptableObject
{
    public int kode_inti;
    public string nama_inti;

    [TextAreaAttribute]
    public string overview_inti;
    public int jumlah_inti;
    public Sprite gambar_2d;
}



