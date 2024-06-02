using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "DataTable/Create Level")]
public class DataLevel : ScriptableObject
{
    DataLevel dataLevel;
    public int level;
    public int maxHealth;
    public int maxMana;
    public int maxExp;

    public int damagebasicAttack1;
    public int damagebasicAttack2;
    public int damagebasicAttack3;
    public int damageskill;


    public int drainbasicAttack1;
    public int drainbasicAttack2;
    public int drainbasicAttack3;
    public int drainskill;

    public int healthregen;
    public int manaregen;
    public int timeregen;
    
}

