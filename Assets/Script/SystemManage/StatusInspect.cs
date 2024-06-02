using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusInspect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Slider expBar;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider manaBar;

    private DataStatus dataStatus;
    private DataLevel dataLevel;

    public void Init(DataStatus dataStatus, DataLevel dataLevel)
    {
        dataStatus = dataStatus;
        dataLevel = dataLevel;
        //
        levelText.text = dataStatus.currentLevel.ToString();
        expBar.maxValue = dataLevel.maxExp;
        expBar.value = dataStatus.currentExp;
        healthBar.maxValue = dataLevel.maxHealth;
        healthBar.value = dataStatus.currentHealth;
        manaBar.maxValue = dataLevel.maxMana;
        manaBar.value = dataStatus.currentMana;
    }


    
}