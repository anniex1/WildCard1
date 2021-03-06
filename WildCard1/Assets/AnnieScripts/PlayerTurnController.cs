﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnController : MonoBehaviour
{
	public int MoveCount;
	public GameObject MovesLeft;
	
	public GameObject PlayerObj;
	public bool MeetHuman; //true if the player is touching a human
	public Button GetHumanButton;
	private GameObject button;
	
    // Start is called before the first frame update
    void Start()
    {
		GetHumanButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
		Dictionary<string, bool> playerStatuses = PlayerObj.GetComponent<PlayerInteraction>().getStatuses();
		MoveCount = PlayerObj.GetComponent<PlayerMovement>().actionCount;
		MeetHuman = playerStatuses["OnHuman"];
		string NewText = "You have " + MoveCount + " moves left";
        MovesLeft.GetComponent<ChangeThisText>().ChangeText(NewText);
		
		HumanButtonHandler();
    }
	
	void HumanButtonHandler() {
		if (MeetHuman) {
			GetHumanButton.interactable = true;
			var NewColorBlock = GetHumanButton.colors;
			NewColorBlock.disabledColor = new Color (0.5f, 0.5f, 0.5f, 1f);
		} else {  //disallow button i
			GetHumanButton.interactable = false;
		}
	}
}
