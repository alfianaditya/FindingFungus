using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class intertable : MonoBehaviour
{
    public Button interact;

    void Start()
    {
        interact = GetComponent<Button>();
    }

    public void inter()
    {
        interact.interactable = true;
    }
}
