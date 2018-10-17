using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom_Clicked : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ZoomClicked()
    {
        if (GameManager.instance.CameraZoomed == false)
        {
            GameManager.instance.CameraZoomed = true;
        }
        else GameManager.instance.CameraZoomed = false;
    }
}
