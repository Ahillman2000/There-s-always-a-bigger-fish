using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum TurnState { START, PLAYER1, PLAYER2, PLAYER3, PLAYER4, END}

public class BattleSystem : MonoBehaviour
{
    public GameObject player1prefab;
    public GameObject player2prefab;
    public GameObject player3prefab;
    public GameObject player4prefab;

    public Transform player1start;
    public Transform player2start;
    public Transform player3start;
    public Transform player4start;

    public TurnState state;

    void Start()
    {
        state = TurnState.START;
        SetupGame();
    }

    void SetupGame()
    {
        Instantiate(player1prefab, player1start);
        Instantiate(player2prefab, player2start);
        Instantiate(player3prefab, player3start);
        Instantiate(player4prefab, player4start);

        state = TurnState.PLAYER1;
        Player1Turn();
    }

    void Player1Turn()
    {
        //PlayerTurnText.text = "Player 1's Turn";
    }
}
