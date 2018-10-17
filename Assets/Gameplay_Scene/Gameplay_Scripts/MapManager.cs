using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

    public List<Unit> gameUnits = new List<Unit>();
    List<Building> gameBuildings = new List<Building>();

    public GameObject BlueArcher;
    public GameObject BlueSword;

    public GameObject RedArcher;
    public GameObject RedSword;

    public GameObject WhiteArcher;
    public GameObject WhiteSword;

    public GameObject RedFactory;
    public GameObject RedResource;

    public GameObject BlueFactory;
    public GameObject BlueResource;

    // Use this for initialization

    public void CreateMap()
    {
        for (int i = 0; i < 12; i++)//foreach (Unit u in gameUnits)
        {
            //UnitCount++;
            int unitX = Random.Range(-8, 4);
            int unitY = Random.Range(-4, 4);
            if (i < 4)
            {
                if(Random.Range(1,3) % 2 == 0)
                {
                    MeleeUnit newMelee = new MeleeUnit("Elven Lancer", "Blue");
                    newMelee.UnitObject = Instantiate(BlueSword, new Vector3(unitX, unitY, 0), Quaternion.identity);
                    gameUnits.Add(newMelee);
                }
                else
                {
                    RangedUnit newRanged = new RangedUnit("Mirkwood Archer", "Blue");
                    newRanged.UnitObject = Instantiate(BlueArcher, new Vector3(unitX, unitY, 0), Quaternion.identity);
                    gameUnits.Add(newRanged);
                }
            }
            if (i >= 4 && i < 8)
            {
                if (Random.Range(1, 3) % 2 == 0)
                {
                    MeleeUnit newMelee = new MeleeUnit("Orc Raider", "Red");
                    newMelee.UnitObject = Instantiate(RedSword, new Vector3(unitX, unitY, 0), Quaternion.identity);
                    gameUnits.Add(newMelee);
                }
                else
                {
                    RangedUnit newRanged = new RangedUnit("Orc Archer", "Red");
                    newRanged.UnitObject = Instantiate(RedArcher, new Vector3(unitX, unitY, 0), Quaternion.identity);
                    gameUnits.Add(newRanged);
                }
            }
            else if (i >= 8 && i < 12)
            {
                if (Random.Range(1, 3) % 2 == 0)
                {
                    MeleeUnit newMelee = new MeleeUnit("Barbarian Swordsman", "Neutral");
                    newMelee.UnitObject = Instantiate(WhiteSword, new Vector3(unitX, unitY, 0), Quaternion.identity);
                    gameUnits.Add(newMelee);
                }
                else
                {
                    RangedUnit newRanged = new RangedUnit("Barbarian Archer", "Nuetral");
                    newRanged.UnitObject = Instantiate(WhiteArcher, new Vector3(unitX, unitY, 0), Quaternion.identity);
                    gameUnits.Add(newRanged);
                }
            }
        }

        for (int b = 0; b < 6; b++)
        {
            switch (b)
            {
                case 0:
                    Resource_Building newResource1 = new Resource_Building("Gold", 1, 100, 100, "Blue");
                    newResource1.BuildingObject = Instantiate(BlueResource, new Vector3(-7.35f, 4, 0), Quaternion.identity);
                    gameBuildings.Add(newResource1);
                    break;
                case 1:
                    Factory_Building newBlueFactory1 = new Factory_Building("Melee", 5, -6.97f, 1.69f, 100, "Blue");
                    newBlueFactory1.BuildingObject = Instantiate(BlueFactory, new Vector3(-7.51f, 2.42f, 0), Quaternion.identity);
                    gameBuildings.Add(newBlueFactory1);
                    break;
                case 2:
                    Factory_Building newFactory2 = new Factory_Building("Melee", 5, -5.3f, -3.4f, 100, "Blue");
                    newFactory2.BuildingObject = Instantiate(BlueFactory, new Vector3(-5.711f, 4, 0), Quaternion.identity);
                    gameBuildings.Add(newFactory2);
                    break;
                case 3:
                    Resource_Building newResource2 = new Resource_Building("Gold", 1, 100, 100, "Red");
                    newResource2.BuildingObject = Instantiate(RedResource, new Vector3(3.5f, -3.84f, 0), Quaternion.identity);
                    gameBuildings.Add(newResource2);
                    break;
                case 4:
                    Factory_Building newRedFactory1 = new Factory_Building("Melee", 5, 0.77f, -3.45f, 100, "Blue");
                    newRedFactory1.BuildingObject = Instantiate(RedFactory, new Vector3(1.51f, -3.85f, 0), Quaternion.identity);
                    gameBuildings.Add(newRedFactory1);
                    break;
                case 5:
                    Factory_Building newRedFactory2 = new Factory_Building("Melee", 5, 2.86f, -2.76f, 100, "Blue");
                    newRedFactory2.BuildingObject = Instantiate(RedFactory, new Vector3(3.59f, -2.152f, 0), Quaternion.identity);
                    gameBuildings.Add(newRedFactory2);
                    break;
            }
        }
    }

    //public static List<Unit> ReturnUnits()
    //{
    //    return gameUnits;
    //}
}
