using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Craft", menuName = "DataTable/Create Ramuan Craft Item", order = 1)]
public class CrafterItemRamuan : ScriptableObject
{
    public RequiredJamur requiredJamur;
    public RequiredInti requiredInti;
    public DataRamuan dataRamuan;
    // public DataJamur dataJamur;
    // public DataInti dataInti;

    [System.Serializable]
   public struct RequiredJamur
    {
        public DataJamur Item;
        public int Amount;
    } 
    [System.Serializable]
   public struct RequiredInti
    {
        public DataInti Item;
        public int Amount;
    } 


    public int makePrice;
    public int quantity;
}
