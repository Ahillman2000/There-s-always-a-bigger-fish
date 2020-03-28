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
        GameObject PLayerBlue = GameObject.FindGameObjectWithTag("PlayerBlue");
        GameObject PlayerRed = GameObject.FindGameObjectWithTag("PlayerRed");
        GameObject PlayerYellow = GameObject.FindGameObjectWithTag("PlayerYellow");
        GameObject PlayerGreen = GameObject.FindGameObjectWithTag("PlayerGreen");
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
                PlayerBlue.transform.position = view;
                Debug.Log("placed player_blue");
            }
            else if (player_selected == 'r')
            {
                PlayerRed.transform.position = view;
                Debug.Log("placed player_red");
            }
            else if (player_selected == 'y')
            {
                PlayerYellow.transform.position = view;
                Debug.Log("placed player_yellow");
            }
            else if (player_selected == 'g')
            {
                PlayerGreen.transform.position = view;
                Debug.Log("placed player_green");
            }
            click_mode = 0;
        }
    }
}