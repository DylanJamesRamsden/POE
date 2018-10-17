using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCloudSpawn : MonoBehaviour {

    public GameObject Cloud1;
    public GameObject Cloud2;

    int Counter = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        int CloudType = Random.Range(0, 2);

        //float CloudX = Random.Range(-10, 300);
        float CloudY = Random.Range(2f, 4.5f);

        Counter++;
        if (Counter == 300)
        {
            int mustSpawn = Random.Range(1, 3);

            if (mustSpawn == 1)
            {
                switch (CloudType)
                {
                    case 0:
                        Instantiate(Cloud1, new Vector2(-10.2f, CloudY), Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(Cloud2, new Vector2(10.2f, CloudY), Quaternion.identity);
                        break;
                }
            }
            Counter = 0;
        }
    }
}
