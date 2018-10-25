using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null; //Creates an instance of the GameManager within unity

    public bool gameActive = false;

    public bool CameraZoomed = false;

    public MapController Map;

    public Text gameTimer;

    public Text redResourceText;
    public Text blueResourceText;

    float nextTime = 0;
    float interval = 1;

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
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        Map = new MapController();
        Map.GenerateUnits();

        CreateMap();
    }
	
	// Update is called once per frame
	void Update () {

        if (Time.time >= nextTime)
        {
            if (gameActive)
            {
                BuildingController();

                if (Map.seconds < 59)
                {
                    Map.seconds++;
                    Map.overallGameTime++;
                }
                else
                {
                    Map.minutes++;
                    Map.seconds = 0;
                }
                if (Map.seconds < 10)
                {
                    gameTimer.text = "Time: " + Map.minutes.ToString() + ":0" + Map.seconds.ToString();
                }
                else gameTimer.text = "Time: " + Map.minutes.ToString() + ":" + Map.seconds.ToString();
            }
            nextTime += interval;
        } //TimerControl

        if (gameActive)
        {
            foreach (Unit u in Map.gameUnits)
            {
                if (u.GetType() == typeof(MeleeUnit)) //This if statements is used to determine which type the Unit is
                {
                    MeleeUnit soldier = (MeleeUnit)u; //This casts the Unit as a MeleeUnit, this allows us to access its properties
                                                      //soldier.closestUnit(UnitsOnMap);
                    if (soldier.IsAlive == true) //This if statements checks if the current Unit is alive or not
                    {
                        if (soldier.Health > 25) //This set of if statements chcks wether the soldier has more than 25 health or if they have less than or equal to 25 health, and runs methods based on the condition met
                        {
                            if (soldier.closestUnit(Map.gameUnits).GetType() == typeof(MeleeUnit))
                            {
                                MeleeUnit enemy = (MeleeUnit)soldier.closestUnit(Map.gameUnits);
                                if (soldier.inRange(soldier.closestUnit(Map.gameUnits)) == false) //This if statement checks whether the current Unit is in range of its target, if it is then there is no point in moving
                                {
                                    //soldier.UnitAnimator.SetBool("isWalking", true);
                                    //soldier.UnitAnimator.SetBool("isidle", false);
                                    if (soldier.UnitObject.transform.position.x < enemy.UnitObject.transform.position.x)
                                    {
                                        soldier.UnitObject.transform.position += new Vector3(soldier.Speed * Time.deltaTime, 0, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.x > enemy.UnitObject.transform.position.x)
                                    {
                                        soldier.UnitObject.transform.position -= new Vector3(soldier.Speed * Time.deltaTime, 0, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.y < enemy.UnitObject.transform.position.y)
                                    {
                                        soldier.UnitObject.transform.position += new Vector3(0, soldier.Speed * Time.deltaTime, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.y > enemy.UnitObject.transform.position.y)
                                    {
                                        soldier.UnitObject.transform.position -= new Vector3(0, soldier.Speed * Time.deltaTime, 0);
                                    }
                                }
                                else
                                {
                                    soldier.UnitAnimator.SetBool("isAttacking", true);
                                    soldier.UnitAnimator.SetBool("isidle", false);
                                    soldier.combatWithEnemy(enemy);
                                }
                            }
                            else if (soldier.closestUnit(Map.gameUnits).GetType() == typeof(RangedUnit))
                            {
                                RangedUnit enemy = (RangedUnit)soldier.closestUnit(Map.gameUnits);
                                if (soldier.inRange(soldier.closestUnit(Map.gameUnits)) == false)
                                {
                                    //soldier.UnitAnimator.SetBool("isWalking", true);
                                    //soldier.UnitAnimator.SetBool("isidle", false);
                                    if (soldier.UnitObject.transform.position.x < enemy.UnitObject.transform.position.x)
                                    {
                                        soldier.UnitObject.transform.position += new Vector3(soldier.Speed * Time.deltaTime, 0, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.x > enemy.UnitObject.transform.position.x)
                                    {
                                        soldier.UnitObject.transform.position -= new Vector3(soldier.Speed * Time.deltaTime, 0, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.y < enemy.UnitObject.transform.position.y)
                                    {
                                        soldier.UnitObject.transform.position += new Vector3(0, soldier.Speed * Time.deltaTime, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.y > enemy.UnitObject.transform.position.y)
                                    {
                                        soldier.UnitObject.transform.position -= new Vector3(0, soldier.Speed * Time.deltaTime, 0);
                                    }
                                }
                                else
                                {
                                    soldier.UnitAnimator.SetBool("isAttacking", true);
                                    soldier.UnitAnimator.SetBool("isidle", false);
                                    soldier.combatWithEnemy(enemy);
                                }
                            }
                            else if (soldier.closestUnit(Map.gameUnits).GetType() == typeof(BarbarianMelee))
                            {
                                BarbarianMelee enemy = (BarbarianMelee)soldier.closestUnit(Map.gameUnits);
                                if (soldier.inRange(soldier.closestUnit(Map.gameUnits)) == false)
                                {
                                    //soldier.UnitAnimator.SetBool("isWalking", true);
                                    //soldier.UnitAnimator.SetBool("isidle", false);
                                    if (soldier.UnitObject.transform.position.x < enemy.UnitObject.transform.position.x)
                                    {
                                        soldier.UnitObject.transform.position += new Vector3(soldier.Speed * Time.deltaTime, 0, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.x > enemy.UnitObject.transform.position.x)
                                    {
                                        soldier.UnitObject.transform.position -= new Vector3(soldier.Speed * Time.deltaTime, 0, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.y < enemy.UnitObject.transform.position.y)
                                    {
                                        soldier.UnitObject.transform.position += new Vector3(0, soldier.Speed * Time.deltaTime, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.y > enemy.UnitObject.transform.position.y)
                                    {
                                        soldier.UnitObject.transform.position -= new Vector3(0, soldier.Speed * Time.deltaTime, 0);
                                    }
                                }
                                else
                                {
                                    soldier.UnitAnimator.SetBool("isAttacking", true);
                                    soldier.UnitAnimator.SetBool("isidle", false);
                                    soldier.combatWithEnemy(enemy);
                                }
                            }
                            else
                            {
                                BarbarianRanged enemy = (BarbarianRanged)soldier.closestUnit(Map.gameUnits);
                                if (soldier.inRange(soldier.closestUnit(Map.gameUnits)) == false)
                                {
                                    //soldier.UnitAnimator.SetBool("isWalking", true);
                                    //soldier.UnitAnimator.SetBool("isidle", false);
                                    if (soldier.UnitObject.transform.position.x < enemy.UnitObject.transform.position.x)
                                    {
                                        soldier.UnitObject.transform.position += new Vector3(soldier.Speed * Time.deltaTime, 0, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.x > enemy.UnitObject.transform.position.x)
                                    {
                                        soldier.UnitObject.transform.position -= new Vector3(soldier.Speed * Time.deltaTime, 0, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.y < enemy.UnitObject.transform.position.y)
                                    {
                                        soldier.UnitObject.transform.position += new Vector3(0, soldier.Speed * Time.deltaTime, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.y > enemy.UnitObject.transform.position.y)
                                    {
                                        soldier.UnitObject.transform.position -= new Vector3(0, soldier.Speed * Time.deltaTime, 0);
                                    }
                                }
                                else
                                {
                                    soldier.UnitAnimator.SetBool("isAttacking", true);
                                    soldier.UnitAnimator.SetBool("isidle", false);
                                    soldier.combatWithEnemy(enemy);
                                }
                            }
                        }
                        else if (soldier.Health <= 25)
                        {
                            int randomDirection = Random.Range(0, 6);

                            if (randomDirection < 5)
                            {
                                moveInRandom(u, randomDirection);
                            }
                            else
                            {
                                if (soldier.HasTurned == false)
                                {
                                    if (soldier.Faction == "Red")
                                    {
                                        soldier.Faction = "Blue";
                                        soldier.Name = "Healed " + soldier.Name;
                                        soldier.HasTurned = true;
                                    }
                                    else
                                    {
                                        soldier.Faction = "Red";
                                        soldier.Name = "Turned " + soldier.Name;
                                        soldier.HasTurned = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            GameObject.Destroy(soldier.UnitObject);
                            Map.gameUnits.Remove(u);
                        }
                    }
                }
                else if (u.GetType() == typeof(RangedUnit)) //This if statements is used to determine which type the Unit is
                {
                    RangedUnit soldier = (RangedUnit)u; //This casts the Unit as a MeleeUnit, this allows us to access its properties
                                                      //soldier.closestUnit(UnitsOnMap);
                    if (soldier.IsAlive == true) //This if statements checks if the current Unit is alive or not
                    {
                        if (soldier.Health > 25) //This set of if statements chcks wether the soldier has more than 25 health or if they have less than or equal to 25 health, and runs methods based on the condition met
                        {
                            if (soldier.closestUnit(Map.gameUnits).GetType() == typeof(MeleeUnit))
                            {
                                MeleeUnit enemy = (MeleeUnit)soldier.closestUnit(Map.gameUnits);
                                if (soldier.inRange(soldier.closestUnit(Map.gameUnits)) == false) //This if statement checks whether the current Unit is in range of its target, if it is then there is no point in moving
                                {
                                    //soldier.UnitAnimator.SetBool("isWalking", true);
                                    //soldier.UnitAnimator.SetBool("isidle", false);
                                    if (soldier.UnitObject.transform.position.x < enemy.UnitObject.transform.position.x)
                                    {
                                        soldier.UnitObject.transform.position += new Vector3(soldier.Speed * Time.deltaTime, 0, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.x > enemy.UnitObject.transform.position.x)
                                    {
                                        soldier.UnitObject.transform.position -= new Vector3(soldier.Speed * Time.deltaTime, 0, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.y < enemy.UnitObject.transform.position.y)
                                    {
                                        soldier.UnitObject.transform.position += new Vector3(0, soldier.Speed * Time.deltaTime, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.y > enemy.UnitObject.transform.position.y)
                                    {
                                        soldier.UnitObject.transform.position -= new Vector3(0, soldier.Speed * Time.deltaTime, 0);
                                    }
                                }
                                else
                                {
                                    soldier.UnitAnimator.SetBool("isAttacking", true);
                                    soldier.UnitAnimator.SetBool("isidle", false);
                                    soldier.combatWithEnemy(enemy);
                                }
                            }
                            else if (soldier.closestUnit(Map.gameUnits).GetType() == typeof(RangedUnit))
                            {
                                RangedUnit enemy = (RangedUnit)soldier.closestUnit(Map.gameUnits);
                                if (soldier.inRange(soldier.closestUnit(Map.gameUnits)) == false)
                                {
                                    //soldier.UnitAnimator.SetBool("isWalking", true);
                                    //soldier.UnitAnimator.SetBool("isidle", false);
                                    if (soldier.UnitObject.transform.position.x < enemy.UnitObject.transform.position.x)
                                    {
                                        soldier.UnitObject.transform.position += new Vector3(soldier.Speed * Time.deltaTime, 0, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.x > enemy.UnitObject.transform.position.x)
                                    {
                                        soldier.UnitObject.transform.position -= new Vector3(soldier.Speed * Time.deltaTime, 0, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.y < enemy.UnitObject.transform.position.y)
                                    {
                                        soldier.UnitObject.transform.position += new Vector3(0, soldier.Speed * Time.deltaTime, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.y > enemy.UnitObject.transform.position.y)
                                    {
                                        soldier.UnitObject.transform.position -= new Vector3(0, soldier.Speed * Time.deltaTime, 0);
                                    }
                                }
                                else
                                {
                                    soldier.UnitAnimator.SetBool("isAttacking", true);
                                    soldier.UnitAnimator.SetBool("isidle", false);
                                    soldier.combatWithEnemy(enemy);
                                }
                            }
                            else if (soldier.closestUnit(Map.gameUnits).GetType() == typeof(BarbarianMelee))
                            {
                                BarbarianMelee enemy = (BarbarianMelee)soldier.closestUnit(Map.gameUnits);
                                if (soldier.inRange(soldier.closestUnit(Map.gameUnits)) == false)
                                {
                                    //soldier.UnitAnimator.SetBool("isWalking", true);
                                    //soldier.UnitAnimator.SetBool("isidle", false);
                                    if (soldier.UnitObject.transform.position.x < enemy.UnitObject.transform.position.x)
                                    {
                                        soldier.UnitObject.transform.position += new Vector3(soldier.Speed * Time.deltaTime, 0, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.x > enemy.UnitObject.transform.position.x)
                                    {
                                        soldier.UnitObject.transform.position -= new Vector3(soldier.Speed * Time.deltaTime, 0, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.y < enemy.UnitObject.transform.position.y)
                                    {
                                        soldier.UnitObject.transform.position += new Vector3(0, soldier.Speed * Time.deltaTime, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.y > enemy.UnitObject.transform.position.y)
                                    {
                                        soldier.UnitObject.transform.position -= new Vector3(0, soldier.Speed * Time.deltaTime, 0);
                                    }
                                }
                                else
                                {
                                    soldier.UnitAnimator.SetBool("isAttacking", true);
                                    soldier.UnitAnimator.SetBool("isidle", false);
                                    soldier.combatWithEnemy(enemy);
                                }
                            }
                            else
                            {
                                BarbarianRanged enemy = (BarbarianRanged)soldier.closestUnit(Map.gameUnits);
                                if (soldier.inRange(soldier.closestUnit(Map.gameUnits)) == false)
                                {
                                    //soldier.UnitAnimator.SetBool("isWalking", true);
                                    //soldier.UnitAnimator.SetBool("isidle", false);
                                    if (soldier.UnitObject.transform.position.x < enemy.UnitObject.transform.position.x)
                                    {
                                        soldier.UnitObject.transform.position += new Vector3(soldier.Speed * Time.deltaTime, 0, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.x > enemy.UnitObject.transform.position.x)
                                    {
                                        soldier.UnitObject.transform.position -= new Vector3(soldier.Speed * Time.deltaTime, 0, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.y < enemy.UnitObject.transform.position.y)
                                    {
                                        soldier.UnitObject.transform.position += new Vector3(0, soldier.Speed * Time.deltaTime, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.y > enemy.UnitObject.transform.position.y)
                                    {
                                        soldier.UnitObject.transform.position -= new Vector3(0, soldier.Speed * Time.deltaTime, 0);
                                    }
                                }
                                else
                                {
                                    soldier.UnitAnimator.SetBool("isAttacking", true);
                                    soldier.UnitAnimator.SetBool("isidle", false);
                                    soldier.combatWithEnemy(enemy);
                                }
                            }
                        }
                        else if (soldier.Health <= 25)
                        {
                            int randomDirection = Random.Range(0, 6);

                            if (randomDirection < 5)
                            {
                                moveInRandom(u, randomDirection);
                            }
                            else
                            {
                                if (soldier.HasTurned == false)
                                {
                                    if (soldier.Faction == "Red")
                                    {
                                        soldier.Faction = "Blue";
                                        soldier.Name = "Healed " + soldier.Name;
                                        soldier.HasTurned = true;
                                    }
                                    else
                                    {
                                        soldier.Faction = "Red";
                                        soldier.Name = "Turned " + soldier.Name;
                                        soldier.HasTurned = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            GameObject.Destroy(soldier.UnitObject);
                            Map.gameUnits.Remove(u);
                        }
                    }
                }
                else if (u.GetType() == typeof(BarbarianMelee)) //This if statements is used to determine which type the Unit is
                {
                    BarbarianMelee soldier = (BarbarianMelee)u; //This casts the Unit as a MeleeUnit, this allows us to access its properties
                                                      //soldier.closestUnit(UnitsOnMap);
                    if (soldier.IsAlive == true) //This if statements checks if the current Unit is alive or not
                    {
                        if (soldier.Health >= 1) //This set of if statements chcks wether the soldier has more than 25 health or if they have less than or equal to 25 health, and runs methods based on the condition met
                        {
                            if (soldier.closestUnit(Map.gameUnits).GetType() == typeof(MeleeUnit))
                            {
                                MeleeUnit enemy = (MeleeUnit)soldier.closestUnit(Map.gameUnits);
                                if (soldier.inRange(soldier.closestUnit(Map.gameUnits)) == false) //This if statement checks whether the current Unit is in range of its target, if it is then there is no point in moving
                                {
                                    //soldier.UnitAnimator.SetBool("isWalking", true);
                                    //soldier.UnitAnimator.SetBool("isidle", false);

                                    if (soldier.UnitAnimator.GetBool("IsWalking") == false)
                                    {
                                        soldier.UnitAnimator.SetBool("isWalking", true);
                                    }

                                    if (soldier.UnitObject.transform.position.x < enemy.UnitObject.transform.position.x)
                                    {
                                        soldier.UnitObject.transform.position += new Vector3(soldier.Speed * Time.deltaTime, 0, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.x > enemy.UnitObject.transform.position.x)
                                    {
                                        soldier.UnitObject.transform.position -= new Vector3(soldier.Speed * Time.deltaTime, 0, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.y < enemy.UnitObject.transform.position.y)
                                    {
                                        soldier.UnitObject.transform.position += new Vector3(0, soldier.Speed * Time.deltaTime, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.y > enemy.UnitObject.transform.position.y)
                                    {
                                        soldier.UnitObject.transform.position -= new Vector3(0, soldier.Speed * Time.deltaTime, 0);
                                    }
                                }
                                else
                                {
                                    soldier.UnitAnimator.SetBool("isAttacking", true);
                                    soldier.UnitAnimator.SetBool("isidle", false);
                                    soldier.combatWithEnemy(enemy);
                                }
                            }
                            else if (soldier.closestUnit(Map.gameUnits).GetType() == typeof(RangedUnit))
                            {
                                RangedUnit enemy = (RangedUnit)soldier.closestUnit(Map.gameUnits);
                                if (soldier.inRange(soldier.closestUnit(Map.gameUnits)) == false)
                                {
                                    //soldier.UnitAnimator.SetBool("isWalking", true);
                                    //soldier.UnitAnimator.SetBool("isidle", false);

                                    if (soldier.UnitAnimator.GetBool("IsWalking") == false)
                                    {
                                        soldier.UnitAnimator.SetBool("isWalking", true);
                                    }

                                    if (soldier.UnitObject.transform.position.x < enemy.UnitObject.transform.position.x)
                                    {
                                        soldier.UnitObject.transform.position += new Vector3(soldier.Speed * Time.deltaTime, 0, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.x > enemy.UnitObject.transform.position.x)
                                    {
                                        soldier.UnitObject.transform.position -= new Vector3(soldier.Speed * Time.deltaTime, 0, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.y < enemy.UnitObject.transform.position.y)
                                    {
                                        soldier.UnitObject.transform.position += new Vector3(0, soldier.Speed * Time.deltaTime, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.y > enemy.UnitObject.transform.position.y)
                                    {
                                        soldier.UnitObject.transform.position -= new Vector3(0, soldier.Speed * Time.deltaTime, 0);
                                    }
                                }
                                else
                                {
                                    soldier.UnitAnimator.SetBool("isAttacking", true);
                                    soldier.UnitAnimator.SetBool("isidle", false);
                                    soldier.combatWithEnemy(enemy);
                                }
                            }
                        }
                        else
                        {
                            GameObject.Destroy(soldier.UnitObject);
                            Map.gameUnits.Remove(u);
                        }
                    }
                }
                else if (u.GetType() == typeof(BarbarianRanged)) //This if statements is used to determine which type the Unit is
                {
                    BarbarianRanged soldier = (BarbarianRanged)u; //This casts the Unit as a MeleeUnit, this allows us to access its properties
                                                                //soldier.closestUnit(UnitsOnMap);
                    if (soldier.IsAlive == true) //This if statements checks if the current Unit is alive or not
                    {
                        if (soldier.Health >= 1) //This set of if statements chcks wether the soldier has more than 25 health or if they have less than or equal to 25 health, and runs methods based on the condition met
                        {
                            if (soldier.closestUnit(Map.gameUnits).GetType() == typeof(MeleeUnit))
                            {
                                MeleeUnit enemy = (MeleeUnit)soldier.closestUnit(Map.gameUnits);
                                if (soldier.inRange(soldier.closestUnit(Map.gameUnits)) == false) //This if statement checks whether the current Unit is in range of its target, if it is then there is no point in moving
                                {
                                    soldier.UnitAnimator.SetBool("isWalking", true);
                                    soldier.UnitAnimator.SetBool("isidle", false);
                                    if (soldier.UnitObject.transform.position.x < enemy.UnitObject.transform.position.x)
                                    {
                                        soldier.UnitObject.transform.position += new Vector3(soldier.Speed * Time.deltaTime, 0, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.x > enemy.UnitObject.transform.position.x)
                                    {
                                        soldier.UnitObject.transform.position -= new Vector3(soldier.Speed * Time.deltaTime, 0, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.y < enemy.UnitObject.transform.position.y)
                                    {
                                        soldier.UnitObject.transform.position += new Vector3(0, soldier.Speed * Time.deltaTime, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.y > enemy.UnitObject.transform.position.y)
                                    {
                                        soldier.UnitObject.transform.position -= new Vector3(0, soldier.Speed * Time.deltaTime, 0);
                                    }
                                }
                                else
                                {
                                    soldier.UnitAnimator.SetBool("isAttacking", true);
                                    soldier.UnitAnimator.SetBool("isidle", false);
                                    soldier.combatWithEnemy(enemy);
                                }
                            }
                            else if (soldier.closestUnit(Map.gameUnits).GetType() == typeof(RangedUnit))
                            {
                                RangedUnit enemy = (RangedUnit)soldier.closestUnit(Map.gameUnits);
                                if (soldier.inRange(soldier.closestUnit(Map.gameUnits)) == false)
                                {
                                    soldier.UnitAnimator.SetBool("isWalking", true);
                                    soldier.UnitAnimator.SetBool("isidle", false);
                                    if (soldier.UnitObject.transform.position.x < enemy.UnitObject.transform.position.x)
                                    {
                                        soldier.UnitObject.transform.position += new Vector3(soldier.Speed * Time.deltaTime, 0, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.x > enemy.UnitObject.transform.position.x)
                                    {
                                        soldier.UnitObject.transform.position -= new Vector3(soldier.Speed * Time.deltaTime, 0, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.y < enemy.UnitObject.transform.position.y)
                                    {
                                        soldier.UnitObject.transform.position += new Vector3(0, soldier.Speed * Time.deltaTime, 0);
                                    }
                                    else if (soldier.UnitObject.transform.position.y > enemy.UnitObject.transform.position.y)
                                    {
                                        soldier.UnitObject.transform.position -= new Vector3(0, soldier.Speed * Time.deltaTime, 0);
                                    }
                                }
                                else
                                {
                                    soldier.UnitAnimator.SetBool("isAttacking", true);
                                    soldier.UnitAnimator.SetBool("isidle", false);
                                    soldier.combatWithEnemy(enemy);
                                }
                            }
                        }
                        else
                        {
                            GameObject.Destroy(soldier.UnitObject);
                            Map.gameUnits.Remove(u);
                        }
                    }
                }
            }
        }
        //else if (gameActive == false)
        //{
        //    foreach(Unit u in Map.gameUnits)
        //    {
        //        if (u.GetType() == typeof(MeleeUnit))
        //        {
        //            MeleeUnit temp = (MeleeUnit)u;
        //            temp.UnitAnimator.SetBool("isIdle", true);
        //            temp.UnitAnimator.SetBool("isWalking", false);
        //            temp.UnitAnimator.SetBool("isAttacking", false);

        //        }
        //        else if (u.GetType() == typeof(RangedUnit))
        //        {
        //            RangedUnit temp = (RangedUnit)u;
        //            temp.UnitAnimator.SetBool("isIdle", true);
        //            temp.UnitAnimator.SetBool("isWalking", false);
        //            temp.UnitAnimator.SetBool("isAttacking", false);
        //        }
        //        else if (u.GetType() == typeof(BarbarianMelee))
        //        {
        //            BarbarianMelee temp = (BarbarianMelee)u;
        //            temp.UnitAnimator.SetBool("isIdle", true);
        //            temp.UnitAnimator.SetBool("isWalking", false);
        //            temp.UnitAnimator.SetBool("isAttacking", false);
        //        }
        //        else
        //        {
        //            BarbarianRanged temp = (BarbarianRanged)u;
        //            temp.UnitAnimator.SetBool("isIdle", true);
        //            temp.UnitAnimator.SetBool("isWalking", false);
        //            temp.UnitAnimator.SetBool("isAttacking", false);
        //        }
        //    }
        //}
	}

    public void BuildingController()
    {
        foreach (Building b in Map.gameBuildings)
        {
            if (b.GetType() == typeof(Resource_Building))
            {
                Resource_Building newResource = (Resource_Building)b;

                if (newResource.Faction == "Red")
                {
                    Map.redResourceCounter += newResource.GenerateResources();
                    redResourceText.text = "RR: " + Map.redResourceCounter.ToString();
                }
                else
                {
                    Map.blueResourceCounter += newResource.GenerateResources();
                    blueResourceText.text = "BR: " + Map.blueResourceCounter.ToString();
                }
            }
            else if (b.GetType() == typeof(Factory_Building))
            {
                if (Map.gameUnits.Count < 12)
                {
                    Factory_Building F = (Factory_Building)b;
                    if (F.Faction == "Red")
                    {
                        Unit newUnit = F.SpawnUnit(Map.overallGameTime, Map.redResourceCounter);
                        if (newUnit != null)
                        {
                            if (newUnit.GetType() == typeof(MeleeUnit))
                            {
                                MeleeUnit M = (MeleeUnit)newUnit;
                                M.UnitObject = Instantiate(RedSword, new Vector3(F.SpawnPointX, F.SpawnPointY, 0), Quaternion.identity);
                                Map.gameUnits.Add(M);
                            }
                            else if (newUnit.GetType() == typeof(RangedUnit))
                            {
                                RangedUnit M = (RangedUnit)newUnit;
                                M.UnitObject = Instantiate(RedArcher, new Vector3(F.SpawnPointX, F.SpawnPointY, 0), Quaternion.identity);
                                Map.gameUnits.Add(M);
                            }
                        }
                    }
                    else if (F.Faction == "Blue")
                    {
                        Unit newUnit = F.SpawnUnit(Map.overallGameTime, Map.blueResourceCounter);
                        if (newUnit != null)
                        {
                            if (newUnit.GetType() == typeof(MeleeUnit))
                            {
                                MeleeUnit M = (MeleeUnit)newUnit;
                                M.UnitObject = Instantiate(BlueSword, new Vector3(F.SpawnPointX, F.SpawnPointY, 0), Quaternion.identity);
                                Map.gameUnits.Add(M);
                            }
                            else if (newUnit.GetType() == typeof(RangedUnit))
                            {
                                RangedUnit M = (RangedUnit)newUnit;
                                M.UnitObject = Instantiate(BlueArcher, new Vector3(F.SpawnPointX, F.SpawnPointY, 0), Quaternion.identity);
                                Map.gameUnits.Add(M);
                            }
                        }
                    }
                }
            }
        }
    }

    public void moveInRandom(Unit soldier, int r) //This method is used to move a Unit in a random direction
    {
        if (soldier.GetType() == typeof(MeleeUnit))
        {
            MeleeUnit scaredSoldier = (MeleeUnit)soldier;
            switch (r) //It bases the random direction decision on a random int variable 
            {
                case 0:
                    {
                        scaredSoldier.UnitObject.transform.position += new Vector3(0, scaredSoldier.Speed * Time.deltaTime, 0); //The units movement is multiplied by its movement speed because it is running 
                        scaredSoldier.Health -= 1;
                    }
                    break;
                case 1:
                    {
                        scaredSoldier.UnitObject.transform.position -= new Vector3(0, scaredSoldier.Speed * Time.deltaTime, 0); //The units movement is multiplied by its movement speed because it is running 
                        scaredSoldier.Health -= 1;
                    }
                    break;
                case 2:
                    {
                        scaredSoldier.UnitObject.transform.position += new Vector3(scaredSoldier.Speed * Time.deltaTime, 0, 0); //The units movement is multiplied by its movement speed because it is running 
                        scaredSoldier.Health -= 1;
                    }
                    break;
                case 3:
                    {
                        scaredSoldier.UnitObject.transform.position += new Vector3(scaredSoldier.Speed * Time.deltaTime, 0, 0); //The units movement is multiplied by its movement speed because it is running 
                        scaredSoldier.Health -= 1;
                    }
                    break;
            }

        }
        else
        {
            RangedUnit scaredSoldier = (RangedUnit)soldier;
            switch (r)
            {
                case 0:
                    {
                        scaredSoldier.UnitObject.transform.position += new Vector3(0, scaredSoldier.Speed * Time.deltaTime, 0); //The units movement is multiplied by its movement speed because it is running 
                        scaredSoldier.Health -= 1;
                    }
                    break;
                case 1:
                    {
                        scaredSoldier.UnitObject.transform.position -= new Vector3(0, scaredSoldier.Speed * Time.deltaTime, 0); //The units movement is multiplied by its movement speed because it is running 
                        scaredSoldier.Health -= 1;
                    }
                    break;
                case 2:
                    {
                        scaredSoldier.UnitObject.transform.position += new Vector3(scaredSoldier.Speed * Time.deltaTime, 0, 0); //The units movement is multiplied by its movement speed because it is running 
                        scaredSoldier.Health -= 1;
                    }
                    break;
                case 3:
                    {
                        scaredSoldier.UnitObject.transform.position += new Vector3(scaredSoldier.Speed * Time.deltaTime, 0, 0); //The units movement is multiplied by its movement speed because it is running 
                        scaredSoldier.Health -= 1;
                    }
                    break;
            }
        }
    }

    void CreateMap()
    {
        foreach(Unit u in Map.gameUnits)
        {
            int unitX = UnityEngine.Random.Range(-8, 4);
            int unitY = UnityEngine.Random.Range(-4, 4);

            if (u.GetType() == typeof(MeleeUnit))
            {
                MeleeUnit M = (MeleeUnit)u;
                if (M.Faction == "Red")
                {
                    M.UnitObject = Instantiate(RedSword, new Vector3(unitX, unitY, 0), Quaternion.identity);
                    M.UnitAnimator = M.UnitObject.GetComponent<Animator>();

                }
                else if (M.Faction == "Blue")
                {
                    M.UnitObject = Instantiate(BlueSword, new Vector3(unitX, unitY, 0), Quaternion.identity);
                    M.UnitAnimator = M.UnitObject.GetComponent<Animator>();
                }
            }
            else if (u.GetType() == typeof(RangedUnit))
            {
                RangedUnit M = (RangedUnit)u;
                if (M.Faction == "Red")
                {
                    M.UnitObject = Instantiate(RedArcher, new Vector3(unitX, unitY, 0), Quaternion.identity);
                    M.UnitAnimator = M.UnitObject.GetComponent<Animator>();
                }
                else if (M.Faction == "Blue")
                {
                    M.UnitObject = Instantiate(BlueArcher, new Vector3(unitX, unitY, 0), Quaternion.identity);
                    M.UnitAnimator = M.UnitObject.GetComponent<Animator>();
                }
            }
            else if (u.GetType() == typeof(BarbarianMelee))
            {
                BarbarianMelee M = (BarbarianMelee)u;
                M.UnitObject = Instantiate(WhiteSword, new Vector3(unitX, unitY, 0), Quaternion.identity);
                M.UnitAnimator = M.UnitObject.GetComponent<Animator>();
            }
            else
            {
                BarbarianRanged M = (BarbarianRanged)u;
                M.UnitObject = Instantiate(WhiteArcher, new Vector3(unitX, unitY, 0), Quaternion.identity);
                M.UnitAnimator = M.UnitObject.GetComponent<Animator>();
            }
        }

        for (int b = 0; b < 6; b++)
        {
            switch (b)
            {
                case 0:
                    Resource_Building newResource1 = (Resource_Building)Map.gameBuildings[0];
                    newResource1.BuildingObject = Instantiate(BlueResource, new Vector3(-7.35f, 4, 0), Quaternion.identity);
                    break;
                case 1:
                    Factory_Building newBlueFactory1 = (Factory_Building)Map.gameBuildings[1];
                    newBlueFactory1.BuildingObject = Instantiate(BlueFactory, new Vector3(-7.51f, 2.42f, 0), Quaternion.identity);
                    break;
                case 2:
                    Factory_Building newBlueFactory2 = (Factory_Building)Map.gameBuildings[2];
                    newBlueFactory2.BuildingObject = Instantiate(BlueFactory, new Vector3(-5.73f, 4.11f, 0), Quaternion.identity);
                    break;
                case 3:
                    Resource_Building newResource2 = (Resource_Building)Map.gameBuildings[3];
                    newResource2.BuildingObject = Instantiate(RedResource, new Vector3(3.4f, -3.8f, 0), Quaternion.identity);
                    break;
                case 4:
                    Factory_Building newRedFactory1 = (Factory_Building)Map.gameBuildings[4];
                    newRedFactory1.BuildingObject = Instantiate(RedFactory, new Vector3(1.9f, -3.8f, 0), Quaternion.identity);
                    break;
                case 5:
                    Factory_Building newRedFactory2 = (Factory_Building)Map.gameBuildings[5];
                    newRedFactory2.BuildingObject = Instantiate(RedFactory, new Vector3(3.68f, -2.57f, 0), Quaternion.identity);
                    break;
            }
        }
    }

    public void SaveGame()
    {
        try
        {
            BinaryFormatter b = new BinaryFormatter();
            FileStream fsOUT = new FileStream("GameEngine.dat", FileMode.Create, FileAccess.Write, FileShare.None);

            using (fsOUT)
            {
                b.Serialize(fsOUT, Map);
                Debug.Log("Gameplay database saved...");
            }
        }
        catch (FileNotFoundException ex)
        {
            Debug.Log("Error Occured" + ex.Message);
        }
    }

    public void LoadGame()
    {
        BinaryFormatter b = new BinaryFormatter();
        FileStream fsIN = new FileStream("GameEngine.dat", FileMode.Open, FileAccess.Read, FileShare.None);

        try
        {
            using (fsIN)
            {
                MapController TempClass = (MapController)b.Deserialize(fsIN);
                Map = TempClass;

                DestroyAllUnits();
                CreateMap();

                if (Map.seconds < 10)
                {
                    gameTimer.text = "Time: " + Map.minutes.ToString() + ":0" + Map.seconds.ToString();
                }
                else gameTimer.text = "Time: " + Map.minutes.ToString() + ":" + Map.seconds.ToString();
            }
        }
        catch (FileNotFoundException ex)
        {
            Debug.Log("Error Occured, no file:" + ex.Message);
        }
    }

    void DestroyAllUnits()
    {
        GameObject[] Unit2Destroy = GameObject.FindGameObjectsWithTag("Unit");

        foreach(GameObject u in Unit2Destroy)
        {
            GameObject.Destroy(u);
        }
    }
}
