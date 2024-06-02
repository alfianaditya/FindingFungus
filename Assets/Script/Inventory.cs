using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Jamur", menuName = "DataTable/Create Inv")]
public class Inventory : ScriptableObject
{
     public List<DataJamur> DJamur = new List<DataJamur>();
     public List<DataInti> DInti = new List<DataInti>();
     public List<DataRamuan> DRamuan = new List<DataRamuan>();
     public List<DataKristal> DKristal = new List<DataKristal>();
     public List<DataBook> DBook = new List<DataBook>();



     public int GetJamurCount(DataJamur _dataJamur)
     {
          return DJamur.Find(x => x == _dataJamur).jumlah_jamur;
     }


     public DataJamur GetJamur(DataJamur _dataJamur)
     {
          return DJamur.Find(x => x == _dataJamur);
     }

     public int GetIntiCount(DataInti _dataInti)
     {
          return DInti.Find(x => x == _dataInti).jumlah_inti;
     }

     public DataInti GetInti(DataInti _dataInti)
     {
          return DInti.Find(x => x == _dataInti);
     }

     
}
