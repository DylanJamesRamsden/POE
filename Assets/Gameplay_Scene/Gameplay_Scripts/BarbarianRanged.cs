﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    class BarbarianRanged : Unit
    {
        public string Name
        {
            get { return base.name; }
            set { base.name = value; }
        }

        //public int XPos
        //{
        //    get { return base.xpos; }
        //    set { base.xpos = value; }
        //}

        //public int YPos
        //{
        //    get { return base.ypos; }
        //    set { base.ypos = value; }
        //}

        public int Speed
        {
            get { return base.speed; }
            set { base.speed = value; }
        }

        public int Health
        {
            get { return base.health; }
            set { base.health = value; }
        }

        public int Attack
        {
            get { return base.attack; }
            set { base.attack = value; }
        }

        public int AttackRange
        {
            get { return base.attackRange; }
            set { base.attackRange = value; }
        }

        public bool IsAlive
        {
            get { return base.isalive; }
            set { base.isalive = value; }
        }

        public string Faction
        {
            get { return base.faction; }
            set { base.faction = value; }
        }

        public int UnitCost
        {
            get { return base.unitcost; }
            set { base.unitcost = value; }
        }

        public GameObject UnitObject
        {
            get { return base.unitobject; }
            set { base.unitobject = value; }
        }

        public BarbarianRanged(string uname, String unitFaction, string unitSymbol, GameObject UnitOb)
        {
            Name = uname;
            //XPos = xP;
            //YPos = yP;
            Health = 100;
            Speed = 3;
            Attack = 50;
            AttackRange = 1;
            Faction = unitFaction;
            IsAlive = true;
            unitcost = 0;
            UnitObject = UnitOb;
        }

        //public override void newPos(int xP, int yP)
        //{
        //    XPos = xP;
        //    YPos = yP;
        //}

        public override void combatWithEnemy(Unit Enemy)
        {
            if (Enemy.GetType() == typeof(MeleeUnit))
            {
                MeleeUnit convertEnemy = (MeleeUnit)Enemy;
                convertEnemy.Health = convertEnemy.Health - Attack;

                if (convertEnemy.Health <= 0)
                {
                    convertEnemy.isDead();
                }
            }
            else
            {
                RangedUnit convertEnemy = (RangedUnit)Enemy;
                convertEnemy.Health = convertEnemy.Health - Attack;

                if (convertEnemy.Health <= 0)
                {
                    convertEnemy.isDead();
                }
            }
        }

    public override bool inRange(Unit Enemy)
    {
        float Distance = 0;

        if (Enemy.GetType() == typeof(MeleeUnit))
        {
            MeleeUnit convertEnemy = (MeleeUnit)Enemy;
            Distance = Math.Abs(UnitObject.transform.position.x - convertEnemy.UnitObject.transform.position.x) + (UnitObject.transform.position.y - convertEnemy.UnitObject.transform.position.y);
        }
        else if (Enemy.GetType() == typeof(RangedUnit))
        {
            RangedUnit convertEnemy = (RangedUnit)Enemy;
            Distance = Math.Abs(UnitObject.transform.position.x - convertEnemy.UnitObject.transform.position.x) + (UnitObject.transform.position.y - convertEnemy.UnitObject.transform.position.y);
        }

        if (Distance <= AttackRange)
        {
            return true;
        }
        else return false;
    }

    public override void isDead()
    {
        if (Health <= 0)
        {
            isalive = false;
            Health = 0;
        }
    }

    public override string toString()
        {
            string Temp = "";
            Temp = "Unit type: Barbarian Ranged \r\n";
            Temp = Temp + "Name: " + Name + "\r\n";
            Temp = Temp + "Faction: " + Faction + "\r\n";
            Temp = Temp + "HP: " + Health.ToString() + "\r\n";
            Temp = Temp + "Damage: " + Attack.ToString() + "\r\n";
            Temp = Temp + "Range: " + AttackRange.ToString() + "\r\n";
            Temp = Temp + "Speed: " + Speed.ToString() + "\r\n";
            return Temp;
        }

    public override Unit closestUnit(Unit[] MapOfUnits) //This method finds the closest enemy unit away from this unit
    {
        Unit ClosestEnemy = this;
        float Distance = 50;

        for (int i = 0; i < 18; i++)
        {
            if (MapOfUnits[i] != null)
            {
                if (MapOfUnits[i].GetType() == typeof(MeleeUnit))
                {
                    MeleeUnit Current = (MeleeUnit)MapOfUnits[i];
                    if (UnitObject.transform.position.x != Current.UnitObject.transform.position.x && UnitObject.transform.position.y != Current.UnitObject.transform.position.y && Current.Faction != Faction && Current.IsAlive == true)
                    {
                        if (Distance > DistanceTo(Current))
                        {
                            Distance = DistanceTo(Current);
                            ClosestEnemy = MapOfUnits[i];
                        }
                    }
                }
                else if (MapOfUnits[i].GetType() == typeof(RangedUnit))
                {
                    RangedUnit Current = (RangedUnit)MapOfUnits[i];
                    if (UnitObject.transform.position.x != Current.UnitObject.transform.position.x && UnitObject.transform.position.y != Current.UnitObject.transform.position.y && Current.Faction != Faction && Current.IsAlive == true)
                    {
                        if (Distance > DistanceTo(Current))
                        {
                            Distance = DistanceTo(Current);
                            ClosestEnemy = MapOfUnits[i];
                        }
                    }
                }
            }
        }
        return ClosestEnemy;
    }

    private float DistanceTo(Unit u) //This method calculates the distance between this unit and another one and then returns it as an int
    {
        if (u.GetType() == typeof(MeleeUnit))
        {
            MeleeUnit m = (MeleeUnit)u;
            float d = Math.Abs(UnitObject.transform.position.x - m.UnitObject.transform.position.x) + Math.Abs(UnitObject.transform.position.y - m.UnitObject.transform.position.y);
            return d;
        }
        else if (u.GetType() == typeof(RangedUnit))
        {
            RangedUnit m = (RangedUnit)u;
            float d = Math.Abs(UnitObject.transform.position.x - m.UnitObject.transform.position.x) + Math.Abs(UnitObject.transform.position.y - m.UnitObject.transform.position.y);
            return d;
        }
        else if (u.GetType() == typeof(BarbarianMelee))
        {
            //BarbarianMelee m = (BarbarianMelee)u;
            //float d = Math.Abs(UnitObject.transform.position.x - m.UnitObject.transform.position.x) + Math.Abs(UnitObject.transform.position.y - m.UnitObject.transform.position.y);
            return 30;
        }
        else
        {
            //BarbarianRanged r = (BarbarianRanged)u;
            //float d = Math.Abs(UnitObject.transform.position.x - m.UnitObject.transform.position.x) + Math.Abs(UnitObject.transform.position.y - m.UnitObject.transform.position.y);
            return 30;
        }
    }
}