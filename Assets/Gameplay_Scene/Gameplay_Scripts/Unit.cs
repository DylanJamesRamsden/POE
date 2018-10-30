using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    [Serializable]
    public abstract class Unit
    {
        protected string name; //Holds the name of the unit

        protected float xpos; //Holds the units x position on the map

        protected float ypos; //Holds the units y position on the map

        protected int speed; //Holds the units running speed, this is only used when the unit is running away from combat

        protected int health; //Holds the units current HP

        protected int attack; //Holds the units attack damage

        protected float attackRange; //Holds the units attack range, varies if the unit is melee or ranged

        protected bool isalive; //Holds the units current alive status; alive or dead

        protected String faction; //Holds the units faction

        protected bool hasTurned; //Holds a boolean which states whether the unit has changed alliances or not

        protected int unitcost; //Holds the production cost of the unit

        [NonSerialized]
        protected GameObject unitobject;

        [NonSerialized]
        protected Animator unitanimator;

        abstract public void updatePos(); //Assigns the unit a new x or y position

        abstract public void combatWithEnemy(Unit Enemy); //This method is used to carry out combat between the unit and its closest enemy

        abstract public void combatWithEnemy(Building EnemyBuilding);

        abstract public bool inRange(Unit Enemy); //This method is used to check if the unit is in range to attack the closest enemy

        abstract public bool inRange(Building EnemyBuilding);

        abstract public Unit closestUnit(List<Unit> MapOfUnits);  //This method is used to obtain the closest enemy

        abstract public Building closestUnit(List<Building> MapOfBuildings);

        abstract public void isDead(); //This method is used to assign the units current alive status

        abstract public string toString(); //This method builds the units information into a string
    }
