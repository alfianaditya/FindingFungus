using UnityEngine;

[CreateAssetMenu(fileName = "New Kristal", menuName = "DataTable/Create Kristal")]
public class DataKristal : ScriptableObject
{
    public int kode_kristal;
    public string nama_kristal;

    [TextAreaAttribute]
    public string overview_kristal;
    public int jumlah_kristal;
    public Sprite gambar_2d;
}



