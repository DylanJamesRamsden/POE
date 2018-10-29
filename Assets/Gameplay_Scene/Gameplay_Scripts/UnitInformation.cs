using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInformation : MonoBehaviour {

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
        foreach(Unit u in Map.gameUnits)
        {
            if (u.GetType() == typeof(MeleeUnit))
            {
                MeleeUnit M = (MeleeUnit)u;
                if (M.UnitObject.transform.position.x == clickedObject.position.x && M.UnitObject.transform.position.y == clickedObject.transform.position.y)
                {
                    objectText.text = M.toString();
                }
            }
            else if (u.GetType() == typeof(RangedUnit))
            {
                RangedUnit M = (RangedUnit)u;
                if (M.UnitObject.transform.position.x == clickedObject.transform.position.x && M.UnitObject.transform.position.y == clickedObject.transform.position.y)
                {
                    objectText.text = M.toString();
                }
            }
            else if (u.GetType() == typeof(BarbarianMelee))
            {
                BarbarianMelee M = (BarbarianMelee)u;
                if (M.UnitObject.transform.position.x == clickedObject.transform.position.x && M.UnitObject.transform.position.y == clickedObject.transform.position.y)
                {
                    objectText.text = M.toString();
                }
            }
            else if (u.GetType() == typeof(BarbarianRanged))
            {
                BarbarianRanged M = (BarbarianRanged)u;
                if (M.UnitObject.transform.position.x == clickedObject.transform.position.x && M.UnitObject.transform.position.y == clickedObject.transform.position.y)
                {
                    objectText.text = M.toString();
                }
            }
        }
    }
}
