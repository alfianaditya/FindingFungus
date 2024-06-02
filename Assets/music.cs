using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    public GameObject music1;
    bool isPlaying = true;
    public void playMusic()
    {
        music1.GetComponent<AudioSource>().Play();
    }
    public void stopMusic()
    {
        music1.GetComponent<AudioSource>().Stop();
    }

    public void pauseMusic()
    {
        if (isPlaying)
        {
            music1.GetComponent<AudioSource>().Pause();
            isPlaying = false;
        }
        else
        {
            music1.GetComponent<AudioSource>().UnPause();
            isPlaying = true;
        }
    }

}
