using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject[] roomArray;
    public int roomNumber;

    public bool movingThroughDoor = false;

    public int humanCount = 0;

    Vector3 TOP = new Vector3(-3.5f, 3);
    Vector3 BOTTOM = new Vector3(-3.5f, -3);
    Vector3 LEFT = new Vector3(-6.5f, 0);
    Vector3 RIGHT = new Vector3(-0.5f, 0);

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

        //Moving through top door
        if(other.tag == "TopDoor")
        {

            if(Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("Move through top door");
                GetComponent<PlayerMovement>().minusAction();

                if (roomNumber == 1)
                {
                    Debug.Log("Move to Room 0");
                    roomArray[1].SetActive(false);
                    roomArray[0].SetActive(true);
                    transform.position = BOTTOM;
                    roomNumber = 0;
                    movingThroughDoor = true;
                }
                else if (roomNumber == 2)
                {
                    Debug.Log("Move to Room 1");
                    roomArray[2].SetActive(false);
                    roomArray[1].SetActive(true);
                    transform.position = BOTTOM;
                    roomNumber = 1;
                    movingThroughDoor = true;
                }
                else if (roomNumber == 4)
                {
                    Debug.Log("Move to Room 2");
                    roomArray[4].SetActive(false);
                    roomArray[2].SetActive(true);
                    transform.position = BOTTOM;
                    roomNumber = 2;
                    movingThroughDoor = true;
                }

            }
        }


        //Moving through bottom door
        if (Input.GetKeyDown(KeyCode.S) && other.tag == "BottomDoor")
        {
            

            Debug.Log("Move through bottom door");
            GetComponent<PlayerMovement>().minusAction();

            if(roomNumber == 0)
            {
                Debug.Log("Move to Room 1");
                roomArray[0].SetActive(false);
                roomArray[1].SetActive(true);
                roomNumber = 1;
                transform.position = TOP;
                movingThroughDoor = true;
            }

            else if(roomNumber == 1)
            {
                Debug.Log("Move to Room 2");
                roomArray[1].SetActive(false);
                roomArray[2].SetActive(true);
                transform.position = TOP;
                roomNumber = 2;
                movingThroughDoor = true;
            }

            else if (roomNumber == 2)
            {
                Debug.Log("Move to Room 2");
                roomArray[2].SetActive(false);
                roomArray[4].SetActive(true);
                transform.position = TOP;
                roomNumber = 4;
                movingThroughDoor = true;
            }



        }


        //Moving through left door
        if (Input.GetKeyDown(KeyCode.A) && other.tag == "LeftDoor")
        {
            Debug.Log("Move through left door");
            GetComponent<PlayerMovement>().minusAction();


            if (roomNumber == 2)
            {
                Debug.Log("Move to Room 3");
                roomArray[2].SetActive(false);
                roomArray[3].SetActive(true);
                transform.position = RIGHT;
                roomNumber = 3;
                movingThroughDoor = true;
            }
            if (roomNumber == 5)
            {
                Debug.Log("Move to Room 2");
                roomArray[5].SetActive(false);
                roomArray[2].SetActive(true);
                transform.position = RIGHT;
                roomNumber = 2;
                movingThroughDoor = true;
            }

        }


        //Moving through right door
        if (Input.GetKeyDown(KeyCode.D) && other.tag == "RightDoor")
        {
            Debug.Log("Move through right door");
            GetComponent<PlayerMovement>().minusAction();

            if (roomNumber == 2)
            {
                Debug.Log("Move to Room 5");
                roomArray[2].SetActive(false);
                roomArray[5].SetActive(true);
                transform.position = LEFT;
                roomNumber = 5;
                movingThroughDoor = true;
            }
            if (roomNumber == 3)
            {
                Debug.Log("Move to Room 2");
                roomArray[3].SetActive(false);
                roomArray[2].SetActive(true);
                transform.position = LEFT;
                roomNumber = 2;
                movingThroughDoor = true;
            }

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
