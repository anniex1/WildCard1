using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandlers : MonoBehaviour
{
	public GameObject PlayerObj;
	public GameObject StoryObj;
	
	private List<string> HumansInParty;
	
	private List<string> HumansOnShip;
	
	private Dictionary<string, string> HiHuman;
	
	private Dictionary<string, string> ByeHuman;
	
	private string NewHumanConseq = "You move slower and have one less action per turn.";
    // Start is called before the first frame update
    void Start()
    {	
		HumansInParty = new List<string>();
		HumansOnShip = new List<string>();
		HumansOnShip.Add("Amanda");
		HumansOnShip.Add("Eric");
		HumansOnShip.Add("Patrick");
		HumansOnShip.Add("Beatrice");
		HumansOnShip.Add("Fernando");
		
		HiHuman = new Dictionary<string, string>();
		HiHuman.Add("Amanda", "Amanda was hiding in a locker. You invite her to join the party.");
		HiHuman.Add("Eric", "Eric definitely wouldn't make it alone. He got lost in a paper bag yesterday. Let's bring him along.");
		HiHuman.Add("Patrick", "You find Patrick about to drink a shot of tequila. How did he sneak that? Better watch him closely.");
		HiHuman.Add("Beatrice", "Beatrice is sneaky. Also she can build a flamethrower with only a fork and a match.");
		HiHuman.Add("Fernando", "Fernando has a lot of tricks up his sleeve. He sleeps with a sword under his pillow.");
		
		ByeHuman = new Dictionary<string, string>();
		ByeHuman.Add("Amanda", "Bye Amanda");
		ByeHuman.Add("Eric", "Bye Eric");
		ByeHuman.Add("Patrick", "Bye Patrick");
		ByeHuman.Add("Beatrice", "Bye Beatrice");
		ByeHuman.Add("Fernando", "Bye Fernando");
		
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
		int nextHuman = Random.Range(0, HumansOnShip.Count);
		string hiHumanName = HumansOnShip[nextHuman];
		HumansOnShip.Remove(hiHumanName);
		HumansInParty.Add(hiHumanName);
		string NewString = HiHuman[hiHumanName] + " " + NewHumanConseq;
		StoryObj.GetComponent<ChangeThisText>().ChangeText(NewString);
		//button should disable bc the human can no longer be picked up
		//this should happen in the PlayerTurnController every Update as long
		//as after the human is met, the Human GameObject is removed
	}
	
	public void SacrificeHuman(int sacrificeNumber = -1) {
		int nextHuman = Random.Range(0, HumansInParty.Count);
		string byeHumanName = HumansInParty[nextHuman];
		HumansInParty.Remove(byeHumanName);
		//HumansOnShip.Add(byeHumanName);
		string NewString = ByeHuman[byeHumanName];
		StoryObj.GetComponent<ChangeThisText>().ChangeText(NewString);
		PlayerObj.GetComponent<PlayerInteraction>().changeHumanCount(sacrificeNumber);
		
		//tell the gameboard to change its state

	}
	
	public void Run() {
		Debug.Log("RUN");
	}
	
}
