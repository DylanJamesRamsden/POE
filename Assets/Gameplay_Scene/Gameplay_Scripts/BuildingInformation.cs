using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingInformation : MonoBehaviour {

    MapController Map;

    Text objectText;

    // Use this for initialization
    void Start () {
        Map = GameManager.instance.Map;

        objectText = (Text)GameObject.Find("UnitInfoDisplay").GetComponentInChildren<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        objectText.text = "";
        Transform clickedObject = GetComponent<Transform>();

        if (clickedObject != null)
            foreach (Building u in Map.gameBuildings)
            {
                if (u.GetType() == typeof(Resource_Building))
                {
                    Resource_Building M = (Resource_Building)u;
                    if (M.BuildingObject.transform.position.x == clickedObject.position.x && M.BuildingObject.transform.position.y == clickedObject.transform.position.y)
                    {
                        objectText.text = M.toString();
                    }
                }
                else if (u.GetType() == typeof(Factory_Building))
                {
                    Factory_Building M = (Factory_Building)u;
                    if (M.BuildingObject.transform.position.x == clickedObject.transform.position.x && M.BuildingObject.transform.position.y == clickedObject.transform.position.y)
                    {
                        objectText.text = M.toString();
                    }
                }
            }

    }

}
