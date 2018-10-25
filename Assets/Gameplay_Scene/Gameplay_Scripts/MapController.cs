using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    [Serializable]
    public class MapController
    {
    public List<Unit> gameUnits = new List<Unit>();
    public List<Building> gameBuildings = new List<Building>();

    public int minutes;
    public int seconds;
    public int overallGameTime;

    public int blueResourceCounter;
    public int redResourceCounter;

    // Use this for initialization
    
    public void GenerateUnits()
    {
        for (int i = 0; i < 12; i++)//foreach (Unit u in gameUnits)
        {
            //UnitCount++;
            if (i < 4)
            {
                if (UnityEngine.Random.Range(1, 3) % 2 == 0)
                {
                    MeleeUnit newMelee = new MeleeUnit("Elven Lancer", "Blue");
                    Debug.Log("Generates units");
                    gameUnits.Add(newMelee);
                }
                else
                {
                    RangedUnit newRanged = new RangedUnit("Mirkwood Archer", "Blue");
                    gameUnits.Add(newRanged);
                }
            }
            if (i >= 4 && i < 8)
            {
                if (UnityEngine.Random.Range(1, 3) % 2 == 0)
                {
                    MeleeUnit newMelee = new MeleeUnit("Orc Raider", "Red");
                    gameUnits.Add(newMelee);
                }
                else
                {
                    RangedUnit newRanged = new RangedUnit("Orc Archer", "Red");
                    gameUnits.Add(newRanged);
                }
            }
            else if (i >= 8 && i < 12)
            {
                if (UnityEngine.Random.Range(1, 3) % 2 == 0)
                {
                    BarbarianMelee newMelee = new BarbarianMelee("Barbarian Swordsman", "Neutral");
                    gameUnits.Add(newMelee);
                }
                else
                {
                    BarbarianRanged newRanged = new BarbarianRanged("Barbarian Archer", "Nuetral");
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
                    gameBuildings.Add(newResource1);
                    break;
                case 1:
                    Factory_Building newBlueFactory1 = new Factory_Building("Melee", 5, -6.97f, 1.69f, 100, "Blue");
                    gameBuildings.Add(newBlueFactory1);
                    break;
                case 2:
                    Factory_Building newFactory2 = new Factory_Building("Ranged", 5, -5.3f, -3.4f, 100, "Blue");
                    gameBuildings.Add(newFactory2);
                    break;
                case 3:
                    Resource_Building newResource2 = new Resource_Building("Gold", 1, 100, 100, "Red");
                    gameBuildings.Add(newResource2);
                    break;
                case 4:
                    Factory_Building newRedFactory1 = new Factory_Building("Melee", 5, 0.77f, -3.45f, 100, "Blue");
                    gameBuildings.Add(newRedFactory1);
                    break;
                case 5:
                    Factory_Building newRedFactory2 = new Factory_Building("Ranged", 5, 2.86f, -2.76f, 100, "Blue");
                    gameBuildings.Add(newRedFactory2);
                    break;
            }
        }
    }
}
