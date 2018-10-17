using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controls : MonoBehaviour {

    public int Speed;

    public Camera MainCamera;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.CameraZoomed == true)
        {
            MainCamera.orthographicSize = 2;
            //if (transform.position.x > -5.5f || transform.position.x < 1.5f || transform.position.y > 3.5f || transform.position.y > -3.2f)
            //{
            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 3f)
            {
                transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -5.5f)
            {
                transform.position -= new Vector3(Speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 3.5f)
            {
                transform.position += new Vector3(0, Speed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -3.2f)
            {
                transform.position -= new Vector3(0, Speed * Time.deltaTime, 0);
            }
            //}
        }
        else
        {
            MainCamera.orthographicSize = 5;
            transform.position = new Vector3(0, 0, -10);
        }
            
    }
}
