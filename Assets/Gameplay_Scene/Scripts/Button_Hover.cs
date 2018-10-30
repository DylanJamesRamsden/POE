using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Hover : MonoBehaviour {

    public GameObject Main1;

    public GameObject Main2;


    // Use this for initialization
    void Start () {
        Main2.SetActive(false);
    }

     public void MouseHovering()
    {
        Main2.SetActive(true);
        Main1.SetActive(false);
    }
}
