using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //private int MoveDistance = 10;

    // 0 = selection
    // 1 = placement
    private int click_mode = 0;

    /* 
     * b = player_blue
     * r = player_red
     * y = player_yellow
     * g = plyer_green
    */ 
    private char player_selected;
    private char player_placed;

    public GameObject PlayerBlue;
    public GameObject PlayerRed;
    public GameObject PlayerYellow;
    public GameObject PlayerGreen;

    void Start()
    {
        GameObject PlayerBlue = GameObject.FindGameObjectWithTag("PlayerBlue");
        GameObject PlayerRed = GameObject.FindGameObjectWithTag("PlayerRed");
        GameObject PlayerYellow = GameObject.FindGameObjectWithTag("PlayerYellow");
        GameObject PlayerGreen = GameObject.FindGameObjectWithTag("PlayerGreen");
    }
    bool Combat(GameObject attacker, GameObject target)
    {
        
        float distance = Mathf.Pow((attacker.transform.position.y - target.transform.position.y), 2) + Mathf.Pow((attacker.transform.position.x - target.transform.position.x), 2);
        distance = Mathf.Pow(distance, 0.5f);
        Debug.Log("The distance to the target is " + distance);
        if (distance > 3)
        {
            Debug.Log("Too far to attack");
            return false;
        }
        else
        {
            Debug.Log(attacker.name + " has fired a shot at " + target.name);
            float hitChance = 100 - (distance * 25);
            int hitRoll = Random.Range(0, 100);
            //Console.WriteLine("chance = " + hitChance);
            //Console.WriteLine("roll = " + hitRoll);
            if (hitRoll < hitChance)
            {
                float damage = (hitChance - hitRoll) * 10;
                target.GetComponent<HPManager>().HP -= damage;
                Debug.Log("Hit, dealing " + damage + " damage to their HP, which is now " + target.GetComponent<HPManager>().HP);
            }
            else
            {
                Debug.Log("Missed the target, perhaps move closer.");

            }
            return true;
        }
    }

    void Update()
    {
        Vector3 view = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        view.z = 0;

        //Debug.Log(Input.mousePosition.x + " , " + Input.mousePosition.y);

        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            if (Input.GetMouseButtonDown(0) && hit && click_mode == 0)
        {

            if (hitInfo.transform.gameObject.name == "player_blue")
            {
                Debug.Log("selected player_blue");
                player_selected = 'b';
                //PlayerBlue.gameObject.GetComponent<HPManager>().HP = 0;
            }
            else if (hitInfo.transform.gameObject.name == "player_red")
            {
                Debug.Log("selected player_red");
                player_selected = 'r';
            }
            else if (hitInfo.transform.gameObject.name == "player_yellow")
            {
                Debug.Log("selected player_yellow");
                player_selected = 'y';
            }
            else if (hitInfo.transform.gameObject.name == "player_green")
            {
                Debug.Log("selected player_green");
                player_selected = 'g';
            }
            click_mode = 1;
        }

        else if (Input.GetMouseButtonDown(0) && click_mode == 1)
        {
            if (player_selected == 'b')
            {
                if ((hitInfo.transform.gameObject.name == "player_green") || (hitInfo.transform.gameObject.name == "player_yellow") || (hitInfo.transform.gameObject.name == "player_red"))
                {
                    Combat(PlayerBlue, hitInfo.transform.gameObject);
                }
                else
                {
                    PlayerBlue.transform.position = view;
                    Debug.Log("placed player_blue");
                }
                
            }
            else if (player_selected == 'r')
            {
                if ((hitInfo.transform.gameObject.name == "player_green") || (hitInfo.transform.gameObject.name == "player_yellow") || (hitInfo.transform.gameObject.name == "player_blue"))
                {
                    Combat(PlayerRed, hitInfo.transform.gameObject);
                }
                else
                {
                    PlayerRed.transform.position = view;
                    Debug.Log("placed player_red");
                }
            }
            else if (player_selected == 'y')
            {
                if ((hitInfo.transform.gameObject.name == "player_green") || (hitInfo.transform.gameObject.name == "player_blue") || (hitInfo.transform.gameObject.name == "player_red"))
                {
                    Combat(PlayerYellow, hitInfo.transform.gameObject);
                }
                else
                {
                    PlayerYellow.transform.position = view;
                    Debug.Log("placed player_yellow");
                }
            }
            else if (player_selected == 'g')
            {
                if ((hitInfo.transform.gameObject.name == "player_yellow") || (hitInfo.transform.gameObject.name == "player_blue") || (hitInfo.transform.gameObject.name == "player_red"))
                {
                    Combat(PlayerGreen, hitInfo.transform.gameObject);
                }
                else
                {
                    PlayerGreen.transform.position = view;
                    Debug.Log("placed player_green");
                }
            }
            click_mode = 0;
        }
    }
}