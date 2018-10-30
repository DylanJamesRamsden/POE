using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    [Serializable]
    class MeleeUnit : Unit
    {
        public string Name
        {
            get { return base. name; }
            set { base.name = value; }
        }

    public float XPos
    {
        get { return base.xpos; }
        set { base.xpos = value; }
    }

    public float YPos
    {
        get { return base.ypos; }
        set { base.ypos = value; }
    }

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

        public float AttackRange
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

        public bool HasTurned
        {
            get { return base.hasTurned; }
            set { base.hasTurned = value; }
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

        public Animator UnitAnimator
        {
            get { return base.unitanimator; }
            set { base.unitanimator = value; }
        }

    public MeleeUnit(string uname, String unitFaction) //Constructor to set the Melee units stats
        {
            Name = uname;
            //XPos = xP;
            //YPos = yP;
            Health = 100; //All units start off with 100 HP, used to balance the game
            Speed = 1;
            Attack = 1;
            AttackRange = 0.1f;
            Faction = unitFaction; //Faction is either red or blue
            HasTurned = false;
            IsAlive = true; //a unit always atarts alive
            UnitCost = 6; //How mant resources it costs to spawn this type of unit
        }

    public override void updatePos()
    {
        XPos = unitobject.transform.position.x;
        YPos = unitobject.transform.position.y;
    }

    public override void combatWithEnemy(Unit Enemy) //Pass through unit object
        {
            if (Enemy.GetType() == typeof(MeleeUnit)) //This cast is used the convert a unit into its current class, this allows for the units properties to be used and called
            {
                MeleeUnit convertEnemy = (MeleeUnit)Enemy;
                    convertEnemy.Health = convertEnemy.Health - Attack;//Enemy's health is minuseed by the units attack

                if (convertEnemy.Health <= 0)
                {
                    convertEnemy.isDead(); // Calls is dead method to change the enemies isAlive status
                }
            }
            else if (Enemy.GetType() == typeof(RangedUnit))
            {
                RangedUnit convertEnemy = (RangedUnit)Enemy;
                convertEnemy.Health = convertEnemy.Health - Attack;

                if (convertEnemy.Health <= 0)
                {
                    convertEnemy.isDead(); // Calls is dead method to change the enemies isAlive status
                }
            }
            else if (Enemy.GetType() == typeof(BarbarianMelee))
            {
                BarbarianMelee convertEnemy = (BarbarianMelee)Enemy;
                convertEnemy.Health = convertEnemy.Health - Attack;

                if (convertEnemy.Health <= 0)
                {
                    convertEnemy.isDead(); // Calls is dead method to change the enemies isAlive status
                }
            }
            else
            {
                BarbarianRanged convertEnemy = (BarbarianRanged)Enemy;
                convertEnemy.Health = convertEnemy.Health - Attack;

                if (convertEnemy.Health <= 0)
                {
                    convertEnemy.isDead(); // Calls is dead method to change the enemies isAlive status
                }
            }
        }

    public override void combatWithEnemy(Building EnemyBuilding)
    {
        if (EnemyBuilding.GetType() == typeof(Resource_Building))
        {
            Resource_Building convertEnemy = (Resource_Building)EnemyBuilding;
            convertEnemy.Health = convertEnemy.Health - Attack;

            if (convertEnemy.Health <= 0)
            {
                convertEnemy.isDead();
            }
        }
        else
        {
            Factory_Building convertEnemy = (Factory_Building)EnemyBuilding;
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
        else if (Enemy.GetType() == typeof(BarbarianMelee))
        {
            BarbarianMelee convertEnemy = (BarbarianMelee)Enemy;
            Distance = Math.Abs(UnitObject.transform.position.x - convertEnemy.UnitObject.transform.position.x) + (UnitObject.transform.position.y - convertEnemy.UnitObject.transform.position.y);
        }
        else
        {
            BarbarianRanged convertEnemy = (BarbarianRanged)Enemy;
            Distance = Math.Abs(UnitObject.transform.position.x - convertEnemy.UnitObject.transform.position.x) + (UnitObject.transform.position.y - convertEnemy.UnitObject.transform.position.y);
        }

        if (Distance <= AttackRange)
        {
            return true;
        }
        else return false;
    }

    public override bool inRange(Building EnemyBuilding)
    {
        float Distance = 0;

        if (EnemyBuilding.GetType() == typeof(Resource_Building))
        {
            Resource_Building convertEnemy = (Resource_Building)EnemyBuilding;
            Distance = Math.Abs(UnitObject.transform.position.x - convertEnemy.BuildingObject.transform.position.x) + (UnitObject.transform.position.y - convertEnemy.BuildingObject.transform.position.y);
        }
        else
        {
            Factory_Building convertEnemy = (Factory_Building)EnemyBuilding;
            Distance = Math.Abs(UnitObject.transform.position.x - convertEnemy.BuildingObject.transform.position.x) + (UnitObject.transform.position.y - convertEnemy.BuildingObject.transform.position.y);
        }

        if (Distance <= AttackRange)
        {
            return true;
        }
        else return false;
    }

    public override void isDead()//Assigns the unit dead
        {
           if (Health <= 0)
            {
                isalive = false;
                Health = 0;
            }
        } 

        public override string toString() //Broken up to be more readible, collects all the units information
        {
            string Temp = "";
            Temp = "Unit type: Melee Unit \r\n";
            Temp = Temp + "Name: " + Name + "\r\n";
            Temp = Temp + "Faction: " + Faction + "\r\n";
            Temp = Temp + "HP: " + Health.ToString() + "\r\n";
            Temp = Temp + "Damage: " + Attack.ToString() + "\r\n";
            Temp = Temp + "Range: " + AttackRange.ToString() + "\r\n";
            Temp = Temp + "Speed: " + Speed.ToString() + "\r\n";
            return Temp;
        }

        public override Unit closestUnit(List<Unit> MapOfUnits) //This method finds the closest enemy unit away from this unit
        {
            Unit ClosestEnemy = this;
            float Distance = 20;

            foreach (Unit u in MapOfUnits)
            { 
                    if (u.GetType() == typeof(MeleeUnit))
                    {
                        MeleeUnit Current = (MeleeUnit)u;
                        if (UnitObject.transform.position.x  != Current.UnitObject.transform.position.x && UnitObject.transform.position.y != Current.UnitObject.transform.position.y && Current.Faction != Faction && Current.IsAlive == true)
                        {
                            if (Distance > DistanceTo(Current))
                            {
                                Distance = DistanceTo(Current);
                                ClosestEnemy = u;
                            }
                        }
                    }
                    else if (u.GetType() == typeof(RangedUnit))
                    {
                        RangedUnit Current = (RangedUnit)u;
                        if (UnitObject.transform.position.x != Current.UnitObject.transform.position.x && UnitObject.transform.position.y != Current.UnitObject.transform.position.y && Current.Faction != Faction && Current.IsAlive == true)
                        {
                            if (Distance > DistanceTo(Current))
                            {
                                Distance = DistanceTo(Current);
                                ClosestEnemy = u;
                            }
                        }
                    }
                    else if (u.GetType() == typeof(BarbarianMelee))
                    {
                        BarbarianMelee Current = (BarbarianMelee)u;
                        if (UnitObject.transform.position.x != Current.UnitObject.transform.position.x && UnitObject.transform.position.y != Current.UnitObject.transform.position.y && Current.Faction != Faction && Current.IsAlive == true)
                        {
                            if (Distance > DistanceTo(Current))
                            {
                                Distance = DistanceTo(Current);
                                ClosestEnemy = u;
                            }
                        }
                    }
                    else
                    {
                        BarbarianRanged Current = (BarbarianRanged)u;
                        if (UnitObject.transform.position.x != Current.UnitObject.transform.position.x && UnitObject.transform.position.y != Current.UnitObject.transform.position.y && Current.Faction != Faction && Current.IsAlive == true)
                        {
                            if (Distance > DistanceTo(Current))
                            {
                                Distance = DistanceTo(Current);
                                ClosestEnemy = u;
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
                BarbarianMelee m = (BarbarianMelee)u;
                float d = Math.Abs(UnitObject.transform.position.x - m.UnitObject.transform.position.x) + Math.Abs(UnitObject.transform.position.y - m.UnitObject.transform.position.y);
                return d;
            }
            else
            {
                BarbarianRanged m = (BarbarianRanged)u;
                float d = Math.Abs(UnitObject.transform.position.x - m.UnitObject.transform.position.x) + Math.Abs(UnitObject.transform.position.y - m.UnitObject.transform.position.y);
                return d;
            }
        }

        public override Building closestUnit(List<Building> MapOfBuildings) //This method finds the closest enemy unit away from this unit
    {
        Building ClosestEnemy = null;
        float Distance = 20;

        foreach (Building u in MapOfBuildings)
        {
            if (u.GetType() == typeof(Resource_Building))
            {
                Resource_Building Current = (Resource_Building)u;
                if (Current.Faction != Faction && Current.isDead() == true)
                {
                    if (Distance > DistanceTo(Current))
                    {
                        Distance = DistanceTo(Current);
                        ClosestEnemy = u;
                    }
                }
            }
            else
            {
                Factory_Building Current = (Factory_Building)u;
                if (Current.Faction != Faction && Current.isDead() == true)
                {
                    if (Distance > DistanceTo(Current))
                    {
                        Distance = DistanceTo(Current);
                        ClosestEnemy = u;
                    }
                }
            }
        }
        return ClosestEnemy;
    }

        private float DistanceTo(Building u) //This method calculates the distance between this unit and another one and then returns it as an int
    {
        if (u.GetType() == typeof(MeleeUnit))
        {
            Resource_Building m = (Resource_Building)u;
            float d = Math.Abs(UnitObject.transform.position.x - m.BuildingObject.transform.position.x) + Math.Abs(UnitObject.transform.position.y - m.BuildingObject.transform.position.y);
            return d;
        }
        else
        {
            Factory_Building m = (Factory_Building)u;
            float d = Math.Abs(UnitObject.transform.position.x - m.BuildingObject.transform.position.x) + Math.Abs(UnitObject.transform.position.y - m.BuildingObject.transform.position.y);
            return d;
        }
    }

}
