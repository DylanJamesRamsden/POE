﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_CloudMovement : MonoBehaviour {

    public GameObject Cloud;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Cloud.transform.Translate(Vector2.right * Time.deltaTime);

        if (Cloud.transform.position.x == -10.5f)
        {
            Destroy(Cloud);
        }
    }
}