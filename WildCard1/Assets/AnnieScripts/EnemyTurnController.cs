using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnController : MonoBehaviour
{
	public GameObject StoryObj;
    // Start is called before the first frame update
    void Start()
    {
		//StoryObj = GameObject.FindWithTag("Story");
		StoryObj.GetComponent<ChangeThisText>().ChangeText("Aliens moved.");
    }

    // Update is called once per frame
    void Update()
    {
		if (StoryObj.GetComponent<ChangeThisText>().CheckText() != "Aliens moved") {
			StoryObj.GetComponent<ChangeThisText>().ChangeText("Aliens moved.");
		}
    }
}
