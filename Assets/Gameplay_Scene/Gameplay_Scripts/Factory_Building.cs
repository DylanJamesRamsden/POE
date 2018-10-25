using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    [Serializable]
    class Factory_Building : Building
    {
    public int Health
    {
        get { return base.health; }
        set { base.health = value; }
    }

    public string Faction
    {
        get { return base.faction; }
        set { base.faction = value; }
    }

    private string unittoproduce;

    public string UnitToProduce
    {
        get { return unittoproduce; }
        set { unittoproduce = value; }
    }

    private int secondsperunit;

    public int SecondsPerUnit
    {
        get { return secondsperunit; }
        set { secondsperunit = value; }
    }

    private int spawnpointx;

    public int SpawnPointX
    {
        get { return spawnpointx; }
        set { spawnpointx = value; }
    }

    private int spawnpointy;

    public int SpawnPointY
    {
        get { return spawnpointy; }
        set { spawnpointy = value; }
    }

    public GameObject BuildingObject
    {
        get { return buildingObject; }
        set { base.buildingObject = value; }
    }

    public Factory_Building(string unitType, int secperUnit, float spawnX, float spawnY, int HP, string fac)
    {
        UnitToProduce = unitType;
        SecondsPerUnit = secperUnit;
        //SpawnPointX = spawnX;
        //SpawnPointY = spawnY;

        Health = HP;
        Faction = fac;
    }

    public override bool isDead() //Checks to see if the building is dead
    {
        if (Health <= 0)
        {
            Health = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string toString() //returns the buildings infomration as a string
    {
        string Temp = "";
        Temp += "Factory Building: \r\n";
        Temp += "Unit production type: " + unittoproduce + "\r\n";
        //Temp += "X position: " + XPos.ToString() + "\r\n";
        //Temp += "Y position: " + YPos.ToString() + "\r\n";
        Temp += "HP: " + Health.ToString() + "\r\n";
        Temp += "Faction: " + Faction + "\r\n";
        //Temp += "Symbol: " + Symbol + "\r\n";
        Temp += "Seconds per a unit: " + SecondsPerUnit.ToString() + "\r\n";
        Temp += "Unit spawn point: " + SpawnPointX.ToString() + "," + SpawnPointY.ToString() + "\r\n";

        return Temp;
    }

    public Unit SpawnUnit(int GameCounter, int ResourceCounter) //This method is used to create a new unit
    {
        if (GameCounter % SecondsPerUnit == 0) //Checks to see if the spawn time has been reached
        {
            if (UnitToProduce == "Melee")
            {
                if (Faction == "Red") //Checks which faction to spawn
                {
                    MeleeUnit newUnit = new MeleeUnit("Young Orc", Faction);
                    if (ResourceCounter >= newUnit.UnitCost) //Checks to see if there are enough resources to spawn the unit
                    {
                        return newUnit;
                    }
                    else return null; //if there are not enough resources then the unit is not created
                }
                else
                {
                    MeleeUnit newUnit = new MeleeUnit("Young Elf", Faction);
                    if (ResourceCounter >= newUnit.UnitCost)
                    {
                        return newUnit;
                    }
                    else return null;
                }
            }
            else
            {
                if (Faction == "Red")
                {
                    RangedUnit newUnit = new RangedUnit("Young Ranger",  Faction);
                    if (ResourceCounter >= newUnit.UnitCost)
                    {
                        return newUnit;
                    }
                    else return null;
                }
                else
                {
                    RangedUnit newUnit = new RangedUnit("Young Elf Archer", Faction);
                    if (ResourceCounter >= newUnit.UnitCost)
                    {
                        return newUnit;
                    }
                    else return null;
                }
            }
        }
        else return null;
    }
}
