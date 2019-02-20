using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeThisText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Text>().text = "Hello";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void ChangeText(string NewText) {
		GetComponent<Text>().text = NewText;
	}
}
