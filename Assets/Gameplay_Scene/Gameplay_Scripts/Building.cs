using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    [Serializable]
    public abstract class Building
    {
        protected int health; //Health of the building

        protected string faction;

        [NonSerialized]
        protected GameObject buildingObject;

        abstract public bool isDead(); //Holds a boolean stating whether the building is dead or not

        abstract public string toString();

        
    }
