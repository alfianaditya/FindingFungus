using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopCoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    void Update()
    {
        coinText.text = Coinmanager.Instance.GetCoin().ToString();
    }
}
