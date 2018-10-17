using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Play : MonoBehaviour {

    public GameObject Play2;
    public GameObject Play1;

    // Use this for initialization
    void Start () {
		
	}

    void OnMouseExit()
    {
        Play2.SetActive(false);
        Play1.SetActive(true);
    }
}
