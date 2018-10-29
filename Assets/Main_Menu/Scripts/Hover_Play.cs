using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover_Play : MonoBehaviour {

    public GameObject Main1;
    public GameObject Second1;
    public GameObject Third1;
    public GameObject Fourth1;

    public GameObject Main2;
    public GameObject Second2;
    public GameObject Third2;
    public GameObject Fourth2;

    public AudioSource ButtonSound;

    // Use this for initialization
    void Start () {
        Main2.SetActive(false);
	}

    void OnMouseEnter()
    {
        Main2.SetActive(true);
        Main1.SetActive(false);

        Second2.SetActive(false);
        Third2.SetActive(false);
        Fourth2.SetActive(false);

        Second1.SetActive(true);
        Third1.SetActive(true);
        Fourth1.SetActive(true);

        ButtonSound.Play();
    }
 
}
