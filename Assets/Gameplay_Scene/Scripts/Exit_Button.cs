using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Button : MonoBehaviour {

    public GameObject Main1;
    public GameObject Main2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Mouse_Leave()
    {
        Main1.SetActive(true);
        Main2.SetActive(false);
    }
}
