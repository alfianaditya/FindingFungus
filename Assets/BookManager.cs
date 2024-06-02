using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : SingletonMonobehaviour<BookManager>
{
    public Dictionary<int, DataJamur> DBook = new Dictionary<int, DataJamur>();

    int index = 1;

    void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);

        foreach (DataJamur jamur in InventoryManagerJamur.Instance.inventory.DJamur)
        {
            // Debug.Log(jamur);
                AddBook(jamur);
            
        }
    }

    public void AddBook(DataJamur _dataJamur)
{
        foreach (KeyValuePair<int, DataJamur> dataJamur in DBook)
        {
            if (dataJamur.Value == _dataJamur)
            {
                return;
            }
        }
        

        if (DBook.ContainsKey(index))
            return;
        
        DBook.Add(index,_dataJamur);
        index++;
    }



    public DataJamur GetBook(int _index)
    {
        if (DBook.ContainsKey(_index))
        {
            return DBook[_index];
        }
        else
        {
            return null;
        }
    }
}
