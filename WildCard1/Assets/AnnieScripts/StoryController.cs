using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryController : MonoBehaviour
{
	
	public int PeopleCount = 2; //number of people that the player has collected
	
	//[Tooltip ("0 = Player Turn, 1 = Enemy Turn, 2 = Alien Encounter")]
	private int PrevTurn = 0;
	public int GameTurn = 0; //player turn, monster turn, or monster encounter
	
	public GameObject PlayerObj;
	public GameObject InventoryObj;
	public GameObject ButtonHandlersObj;
	public GameObject StoryObj;
	
	[Header("0 = Player, 1 = Enemy, 2 = Encounter")]
	public GameObject[] GameTurns;
	
	public GameObject TurnText;
	private string[] TurnNames = {"Player Turn", "Alien Turn", "Alien Encounter"};
	
	
	public bool cantMove;
	
    // Start is called before the first frame update
    void Start()
    {
		PlayerObj = GameObject.FindWithTag("Player");
		StoryObj = GameObject.FindWithTag("Story");
		GameTurns[0].SetActive(true);
        GameTurns[1].SetActive(false);
		GameTurns[2].SetActive(false);
		GameTurns[0].GetComponent<PlayerTurnController>().PlayerObj = PlayerObj;
		GameTurns[2].GetComponent<AlienEncounterController>().PlayerObj = PlayerObj;
		ButtonHandlersObj.GetComponent<ButtonHandlers>().InventoryObj = InventoryObj;
		
		InventoryObj.GetComponent<ChangeThisText>().ChangeText("Inventory: Empty");
		
    }

    // Update is called once per frame
    void Update()
    {
		
		Dictionary<string, bool> playerStatuses = PlayerObj.GetComponent<PlayerInteraction>().getStatuses();
		if (PlayerObj.GetComponent<PlayerTurn>().getEnemyMovingStatus()) {
			GameTurn = 1;
			//Debug.Log("Enemy Turn");
		} else if (playerStatuses["OnEnemy"]) {
			GameTurn = 2;
			//Debug.Log("Alien Encounter");
		} else {
			GameTurn = 0;
			//Debug.Log("Player Turn");
		}
		
		
		//GetGameTurn();
        if (PrevTurn != GameTurn) {
			PrevTurn = GameTurn;
			//run through the story modes and change the story
			for (int i = 0; i < GameTurns.Length; i++) {
				if (GameTurn != i) {
					GameTurns[i].SetActive(false);
				} else {
					GameTurns[i].SetActive(true);
					TurnText.GetComponent<ChangeThisText>().ChangeText(TurnNames[i]);
				}
			}
		}
		
		
		
		switch (GameTurn) { //different things that will happen depending on the turn
			case 0:
				cantMove = false;
				break;
			case 1:
			    cantMove = true;
				break;
			case 2:
				cantMove = true;
				break;
		}

    }
	

}
