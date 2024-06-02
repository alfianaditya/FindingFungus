using UnityEngine;

[CreateAssetMenu(fileName = "New Item Shop", menuName = "DataTable/Create Inti Shop Item", order = 1)]
public class ShopItemInti : ScriptableObject
{
    public DataInti dataInti;
    public int sellPrice;
    public int quantity;
}
