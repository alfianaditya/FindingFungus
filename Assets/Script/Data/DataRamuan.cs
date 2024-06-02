using UnityEngine;

[CreateAssetMenu(fileName = "New Ramuan", menuName = "DataTable/Create Ramuan")]

public class DataRamuan : ScriptableObject
{
    public int kode_ramuan;
    public string nama_ramuan;

    [TextAreaAttribute]
    public string overview_ramuan;
    public int jumlah_ramuan;
    public int tambah_mana;
    public int tambah_hp;
    public string text_status_ramuan;
    public Sprite gambar_2d;
    public int heal_amount;
}

