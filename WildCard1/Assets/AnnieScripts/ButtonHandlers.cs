using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandlers : MonoBehaviour
{
	public GameObject PlayerObj;
	public GameObject StoryObj;
    // Start is called before the first frame update
    void Start()
    {
        PlayerObj = GameObject.FindWithTag("Player");
		StoryObj = GameObject.FindWithTag("Story");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void CollectHuman() {
		Debug.Log("New friends");
		PlayerObj.GetComponent<PlayerInteraction>().changeHumanCount(1);
		string NewString = "Amanda was hiding in a locker. You invite her to join your party. You move slower and have one less action per turn";
		StoryObj.GetComponent<ChangeThisText>().ChangeText(NewString);
		//button should disable bc the human can no longer be picked up
		//this should happen in the PlayerTurnController every Update as long
		//as after the human is met, the Human GameObject is removed
	}
}
