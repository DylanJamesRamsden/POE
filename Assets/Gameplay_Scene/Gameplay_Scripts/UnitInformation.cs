using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInformation : MonoBehaviour {

    MapController Map;

    public Text objectText;  

	// Use this for initialization
	void Start () {
        Map = GameManager.instance.Map;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        Transform clickedObject = GetComponent<Transform>();
        if (clickedObject != null)
            Debug.Log(clickedObject.position.x);

        foreach(Unit u in Map.gameUnits)
        {
            Debug.Log("forech Woks");
            if (u.GetType() == typeof(MeleeUnit))
            {
                MeleeUnit M = (MeleeUnit)u;
                Debug.Log(M.UnitObject.transform.position.x + " " + clickedObject.position.x);
                if (M.UnitObject.transform.position.x == clickedObject.position.x && M.UnitObject.transform.position.y == clickedObject.transform.position.y)
                {
                    objectText.text = M.toString();
                    Debug.Log("Displaying unit");
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
