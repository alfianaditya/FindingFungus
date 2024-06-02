using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settrue : MonoBehaviour
{
    public GameObject UI_Game;
    public GameObject UI_Loading;

    public void game()
    {
        UI_Game.SetActive(true);
        UI_Loading.SetActive(false);
        Debug.Log("Game is resumed");
    }
}
