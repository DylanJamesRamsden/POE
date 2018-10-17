using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null; //Creates an instance of the GameManager within unity

    public bool CameraZoomed = false;
    MapManager Map;
    // Use this for initialization
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        Map = GetComponent<MapManager>();
        Map.CreateMap();
        Map.un
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
