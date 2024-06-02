using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _pauseObjects;

    private void Update()
    {

            if (_pauseObjects[0].activeSelf == true)
            {
                Pause();
            }
            else
            {
                Resume();
            }

    }

    void Pause()
    {
        Time.timeScale = 0;
        Debug.Log("Game is paused");
    }

    void Resume()
    {
        Time.timeScale = 1;
        // Debug.Log("Game is resumed");

    }

    


}
