using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienEncounterController : MonoBehaviour
{
	//use this to set the canvases buttons enabled or disabled
	
	public Button SacrificeButton;
	public int NumMaxSacrifice;
	public GameObject PlayerObj;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		NumMaxSacrifice = PlayerObj.GetComponent<PlayerInteraction>().humanCount;
        if (NumMaxSacrifice > 0) {
			SacrificeButton.interactable = true;
			var NewColorBlock = SacrificeButton.colors;
			NewColorBlock.disabledColor = new Color (0.5f, 0.5f, 0.5f, 1f);
		} else {
			SacrificeButton.interactable = false;
		}
    }
}
