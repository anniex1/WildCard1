using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    public bool playerTurn = true;

    //List of Enemy gameobjects that are supposed to move only ONE space
    public GameObject[] oneSpaceEnemies;

    //List of Enemy gameobjects that are supposed to move TWO spaces
    public GameObject[] twoSpaceEnemies;

    public bool enemyMoving;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if player is out of actions:
        if (GetComponent<PlayerMovement>().actionCount == 0)
        {
            playerTurn = false;
            Debug.Log("Enemy Turn");

            //---------------------------------------------------------
            // Stuff below is what happens while it isn't the player's turn
            //----------------------------------------------------------

            //Moves enemies that are supposed to move ONE space
            for(int i = 0; i < oneSpaceEnemies.Length; i++)
            {
                if(oneSpaceEnemies[i].activeInHierarchy) //This if statement makes sure enemy only moves if player is in that room
                {
                    enemyMoving = true;


                    //Makes enemy move once after a delay; PROBLEM: player can move during that delay
                    StartCoroutine(oneSpaceEnemies[i].GetComponent<EnemyFollowing>().MoveOneSpace());                  
                }
                
            }

            //Moves enemies that are supposed to move TWO spaces
            for (int i = 0; i < twoSpaceEnemies.Length; i++)
            {
                if (twoSpaceEnemies[i].activeInHierarchy) //This if statement makes sure enemy only moves if player is in that room
                {
                    enemyMoving = true;


                    //Makes enemy move twice with delays; PROBLEM: player can move during that delay
                    StartCoroutine(twoSpaceEnemies[i].GetComponent<EnemyFollowing>().MoveTwoSpaces());
                }
            }




            //-------------NOW PLAYER'S TURN-----------------------------

            playerTurn = true;

            if(playerTurn)
            {
                GetComponent<PlayerMovement>().actionCount = GetComponent<PlayerMovement>().maxActions; // resets player's actions to max actions
                playerTurn = true;
                Debug.Log("Now Player's Turn");
            }
            
        }
    }

}
