using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static DataStatus;

public class StatusManager : MonoBehaviour
{
    public static StatusManager Instance;
    public List<DataLevel> DLevel;

    private DataStatus dataStatus;
    private DataLevel dataLevel;

    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Slider expBar;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider manaBar;
    public Action OnStatusChange;

    public void CallOnStatusChange()
    {
        OnStatusChange?.Invoke();        
    }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StatusCharacter();
    }

    void OnEnable()
    {
        OnStatusChange += StatusCharacter;
    }

    void OnDisable()
    {
        OnStatusChange -= StatusCharacter;
    }

    public void StatusCharacter()
    {
        //
        levelText.text = dataStatus.currentLevel.ToString();
        expBar.maxValue = dataLevel.maxExp;
        expBar.value = dataStatus.currentExp;
        healthBar.maxValue = dataLevel.maxHealth;
        healthBar.value = dataStatus.currentHealth;
        manaBar.maxValue = dataLevel.maxMana;
        manaBar.value = dataStatus.currentMana;
    }

    // public void AddStatus(DataStatus status, int Qty)
    // {
    //     if (status.currentLevel > 0)
    //     {
    //         Debug.Log("masuk if");

    //         dataStatus.currentLevel += Qty;

    //     }
    //     else
    //     {
    //         Debug.Log("masuk else");
    //         dataStatus.currentLevel = 0;
    //     }
    //     CallOnStatusChange();
    // }


}