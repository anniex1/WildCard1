using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject[] roomArray;
    public int roomNumber;

    public int humanCount = 0;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
 
        /* ------------------
         * DOOR INTERACTIONS
         * ------------------*/

        if(other.tag == "TopDoor")
        {

            if(Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("Move through top door");
                GetComponent<PlayerMovement>().minusAction();

            }
        }

        if (Input.GetKeyDown(KeyCode.S) && other.tag == "BottomDoor")
        {
            Debug.Log("Move through bottom door");
            GetComponent<PlayerMovement>().minusAction();

            if(roomNumber == 0)
            {;
                Debug.Log("Move to Room 1");
            }

        }

        if (Input.GetKeyDown(KeyCode.A) && other.tag == "LeftDoor")
        {
            Debug.Log("Move through left door");
            GetComponent<PlayerMovement>().minusAction();

        }

        if (Input.GetKeyDown(KeyCode.D) && other.tag == "RightDoor")
        {
            Debug.Log("Move through right door");
            GetComponent<PlayerMovement>().minusAction();

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("OOF, hit an enemy!");
        }

        if(other.gameObject.tag == "Human")
        {
            Debug.Log("YOU MET A HOOMAN");
        }
    }

    public void changeHumanCount(int n)
    {
        humanCount+=n;
    }
}
