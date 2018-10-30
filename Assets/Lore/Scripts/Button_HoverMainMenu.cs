using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_HoverMainMenu : MonoBehaviour {

    public GameObject Main1;
    public GameObject Main2;

    public AudioSource ButtonSound;

	// Use this for initialization
	void Start () {
        Main2.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter()
    {
        Main1.SetActive(false);
        Main2.SetActive(true);

        ButtonSound.Play();
    }

}
