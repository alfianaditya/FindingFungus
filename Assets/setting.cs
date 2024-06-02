using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class setting : MonoBehaviour
{
    public Slider slider ;

    void Start()
    {
        AudioListener.volume = 100;
    }
    void Update()
    {
        AudioListener.volume = slider.value;
    }
}
