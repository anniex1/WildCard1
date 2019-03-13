using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumansEscaped : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int count = StaticScript.HumCount;

        if(count<=0)
            GetComponent<Text>().text = "YOU SAVED YOURSELF. CAN YOU HEAR THE VOICES OF YOUR FALLEN BRETHEREN?";

        else
            GetComponent<Text>().text = "YOU SAVED " + StaticScript.HumCount + " HUMANS!!!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
