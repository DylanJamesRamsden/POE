using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStopMusic : MonoBehaviour {

    public AudioSource MenuMusic;
    int MusicCounter = 0;

	// Use this for initialization
	void Start () {
		
	}
	
    void OnMouseDown()
    {
        MusicCounter++;

        if (MusicCounter % 2 > 0)
        {
            MenuMusic.Pause();
        }
        else MenuMusic.Play();
    }

    public void MusicStop()
    {
        MusicCounter++;

        if (MusicCounter % 2 > 0)
        {
            MenuMusic.Pause();
        }
        else MenuMusic.Play();
    }
}
