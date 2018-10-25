using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPauseControls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        GameManager.instance.gameActive = true;
    }

    public void PauseGame()
    {
        GameManager.instance.gameActive = false;
    }
}
