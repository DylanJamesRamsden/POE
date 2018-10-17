using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Hover : MonoBehaviour {

    public GameObject Main1;

    public GameObject Main2;

    public AudioSource ButtonSound;


    // Use this for initialization
    void Start () {
        Main2.SetActive(false);
    }

     public void MouseHovering()
    {
        Debug.Log("works");
        Main2.SetActive(true);
        Main1.SetActive(false);

        ButtonSound.Play();
    }
}
