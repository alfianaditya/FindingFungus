using UnityEngine;

[CreateAssetMenu(fileName = "New Jamur", menuName = "DataTable/Create Jamur")]
public class DataJamur : ScriptableObject
{
    public int kode_jamur;
    public string nama_jamur;
    public string binomial;
    public string kingdom;
    public string genus;
    public string famili;
    public string kelas;
    public string ordo;
    public string spesies;
    public string jenis;

    [TextAreaAttribute]
    public string tentang_jamur;

    [TextAreaAttribute]
    public string overview_jamur;

    public int jumlah_jamur;
    public Sprite gambar_2d;
    public Sprite gambar_3d;

}



