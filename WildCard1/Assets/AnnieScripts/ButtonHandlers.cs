using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandlers : MonoBehaviour
{
	public GameObject PlayerObj;
	public GameObject StoryObj;
	public GameObject InventoryObj;
	//public GameObject EndObj;
	public string SceneName = "GameOverScene";
	
	private List<string> HumansInParty;
	
	private List<string> HumansOnShip;
	
	private Dictionary<string, string> HiHuman;
	
	private Dictionary<string, string> ByeHuman;
	
	private string NewHumanConseq = "Your party moves slower and you have one less action per turn.";
    // Start is called before the first frame update
    void Start()
    {	
		HumansInParty = new List<string>();
		HumansOnShip = new List<string>();
		HumansOnShip.Add("Amanda");
		HumansOnShip.Add("Erick");
		HumansOnShip.Add("Patrick");
		HumansOnShip.Add("Beatrice");
		HumansOnShip.Add("Fernando");
		HumansOnShip.Add("Laura");
		HumansOnShip.Add("Jeremy");
		HumansOnShip.Add("Kristin");
		HumansOnShip.Add("Hugh");
		HumansOnShip.Add("Santino");
		
		HiHuman = new Dictionary<string, string>();
		HiHuman.Add("Amanda", "Amanda was hiding in a locker. You invite her to join the party.");
		HiHuman.Add("Erick", "Erick definitely wouldn't make it alone. He got lost in a paper bag yesterday. Let's bring him along.");
		HiHuman.Add("Patrick", "You find Patrick about to drink a shot of tequila. How did he sneak that onboard? Better watch him closely.");
		HiHuman.Add("Beatrice", "Beatrice is sneaky. Also she can build a flamethrower with only a fork and a match.");
		HiHuman.Add("Fernando", "Fernando has a lot of tricks up his sleeve. He sleeps with a sword under his pillow.");
		HiHuman.Add("Laura", "Laura single-handedly designed the entire space shuttle. She doesn't need you but you definitely need her.");
		HiHuman.Add("Jeremy", "You found Jeremy just sitting. He's a pretty okay guy.");
		HiHuman.Add("Kristin", "You find Kristin hiding behind the curtains. Not a smart hiding place, but she'll probably have a use somehow.");
		HiHuman.Add("Hugh", "You find Hugh wielding a torch at some aliens. You really shouldn't have fire but bravery is a virtue in these situations.");
		HiHuman.Add("Santino", "Santino won't let go of his pet fish...oh well. In a future desperate time, some sashimi might lift our spirits.");
		
		ByeHuman = new Dictionary<string, string>();
		ByeHuman.Add("Amanda", "Amanda curses at you as the alien drags her away.");
		ByeHuman.Add("Erick", "The alien smacks it's lips and Erick shivers.");
		ByeHuman.Add("Patrick", "You watch as Patrick makes a run for it. The alien quickly outruns him and they disappear around the corner.");
		ByeHuman.Add("Beatrice", "Bye Beatrice");
		ByeHuman.Add("Fernando", "Fernando gamely meets his fate.");
		ByeHuman.Add("Laura", "The alien tosses Laura into its mouth and she disappears with a single crunch.");
		ByeHuman.Add("Jeremy", "Jeremy looks at you with betrayal in his eyes.");
		ByeHuman.Add("Kristin", "Kristin tries hiding behind the curtains again. ...");
		ByeHuman.Add("Hugh", "Hugh unsheathes hidden knives with a snick. Apparently aliens have big hand knives too. OwO");
		ByeHuman.Add("Santino", "Santino. His name pretty much rhymes with sacrifice.");
		
        PlayerObj = GameObject.FindWithTag("Player");
		//StoryObj = GameObject.FindWithTag("Story");

	}
	
    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void DisableButtonOnClick() {
		GetComponent<Button>().interactable = false;
		
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


        //Stuff Ryan Did:
        PlayerObj.GetComponent<PlayerMovement>().MinusAction();
        PlayerObj.GetComponent<PlayerInteraction>().takeHuman = true;
        //---
		
		string invS = "Inventory: " + PlayerObj.GetComponent<PlayerInteraction>().humanCount + " humans";
		InventoryObj.GetComponent<ChangeThisText>().ChangeText(invS);
    }
	
	public void SacrificeHuman() {
		int nextHuman = Random.Range(0, HumansInParty.Count);
		string byeHumanName = HumansInParty[nextHuman];
		HumansInParty.Remove(byeHumanName);
		//HumansOnShip.Add(byeHumanName);
		string NewString = ByeHuman[byeHumanName];
		StoryObj.GetComponent<ChangeThisText>().ChangeText(NewString);
		
		//tell the gameboard to change its state
		//Debug.Log(sacrificeNumber);
		PlayerObj.GetComponent<PlayerInteraction>().changeHumanCount(-1); //sacrifice one human
       

        //Stuff Ryan Did:
        PlayerObj.GetComponent<PlayerInteraction>().sacrificedHuman = true;
        //---
		
		string invS = "Inventory: " + PlayerObj.GetComponent<PlayerInteraction>().humanCount + " humans";
		InventoryObj.GetComponent<ChangeThisText>().ChangeText(invS);
    }
	
	public void FightAlien() {
		int winChance = Random.Range(0, 2);
		if (winChance == 1) {
            //mimics a human being sacrificed so the enemy goes away
            StoryObj.GetComponent<ChangeThisText>().ChangeText("Your gamble paid off, and you flex your muscles in a victory pose" +
                "as you stand over the dead alien's carcass");
            PlayerObj.GetComponent<PlayerInteraction>().sacrificedHuman = true;
		} else {
			//EndObj.SetActive(true);
			SceneManager.LoadScene(SceneName);
		}
	}
	
}
