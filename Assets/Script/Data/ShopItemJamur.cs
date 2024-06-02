using UnityEngine;

[CreateAssetMenu(fileName = "New Item Shop", menuName = "DataTable/Create Jamur Shop Item", order = 1)]
public class ShopItemJamur : ScriptableObject
{
    public DataJamur dataJamur;
    public int buyPrice;
    public int sellPrice;
    public int quantity;
}
