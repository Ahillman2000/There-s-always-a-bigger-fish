using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingGold : MonoBehaviour
{
    public GameObject PlayerBlue;
    public GameObject PlayerRed;
    public GameObject PlayerYellow;
    public GameObject PlayerGreen;
    public int PlayerBlueGold = 0;
    public int PlayerRedGold = 0;
    public int PlayerYellowGold = 0;
    public int PlayerGreenGold = 0;
    public int turnCount = 0;


    void OnTriggerEnter(Collider Gold)
    {
        if (Gold.CompareTag("PlayerBlue"))
        {
            collectingGold();
            PlayerBlueGold = +100;
        }
        if (Gold.CompareTag("PlayerRed"))
        {
            collectingGold();
            PlayerRedGold = +100;
        }
        if (Gold.CompareTag("PlayerYellow"))
        {
            collectingGold();
            PlayerYellowGold = +100;
        }
        if (Gold.CompareTag("PlayerGreen"))
        {
            collectingGold();
            PlayerGreenGold = +100;
        }
    }

    // Update is called once per frame
    void collectingGold()
    {
        Destroy(gameObject);


        //  WaitWhile (public int turncount == 5);
        //Respawn Gold 
    }

}
