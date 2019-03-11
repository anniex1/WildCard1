using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject[] roomArray;
    public int roomNumber;

    public bool movingThroughDoor = false;

    public int humanCount = 0;

    public bool takeHuman = false;
    public bool sacrificedHuman = false;

    Vector3 TOP = new Vector3(-3.5f, 3);
    Vector3 BOTTOM = new Vector3(-3.5f, -3);
    Vector3 LEFT = new Vector3(-6.5f, 0);
    Vector3 RIGHT = new Vector3(-0.5f, 0);

	
	private bool OnHuman = false;
	private bool OnEnemy = false;
	private Dictionary<string, bool> statuses = new Dictionary<string, bool>();
	private bool triggered = true;
	private Collider2D otherTrigger;
	
    // Start is called before the first frame update
    void Start()
    {
		statuses.Add("OnHuman", OnHuman);
		statuses.Add("OnEnemy", OnEnemy);
    }

    // Update is called once per frame
    void Update()
    {
		if (triggered && !this.otherTrigger) {
			OnHuman = false;
			OnEnemy = false;
		}
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (GetComponent<PlayerMovement>().actionCount > 0)
        {
            /* ------------------
             * DOOR INTERACTIONS
             * ------------------*/

            //Moving through top door
            if (other.tag == "TopDoor")
            {

                if (Input.GetKeyDown(KeyCode.W))
                {
                    Debug.Log("Move through top door");
                    GetComponent<PlayerMovement>().MinusAction();

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
                    else if (roomNumber == 6)
                    {
                        Debug.Log("Move to Room 5");
                        roomArray[6].SetActive(false);
                        roomArray[5].SetActive(true);
                        transform.position = BOTTOM;
                        roomNumber = 5;
                        movingThroughDoor = true;
                    }
                    else if (roomNumber == 7)
                    {
                        Debug.Log("Move to Room 6");
                        roomArray[7].SetActive(false);
                        roomArray[6].SetActive(true);
                        transform.position = BOTTOM;
                        roomNumber = 6;
                        movingThroughDoor = true;
                    }
                    else if (roomNumber == 8)
                    {
                        Debug.Log("Move to Room 3");
                        roomArray[8].SetActive(false);
                        roomArray[3].SetActive(true);
                        transform.position = BOTTOM;
                        roomNumber = 3;
                        movingThroughDoor = true;
                    }
                    else if (roomNumber == 9)
                    {
                        Debug.Log("Move to Room 8");
                        roomArray[9].SetActive(false);
                        roomArray[8].SetActive(true);
                        transform.position = BOTTOM;
                        roomNumber = 8;
                        movingThroughDoor = true;
                    }
                    else if (roomNumber == 10)
                    {
                        Debug.Log("Move to Room 4");
                        roomArray[10].SetActive(false);
                        roomArray[4].SetActive(true);
                        transform.position = BOTTOM;
                        roomNumber = 4;
                        movingThroughDoor = true;
                    }

                }
            }


            //Moving through bottom door
            if (Input.GetKeyDown(KeyCode.S) && other.tag == "BottomDoor")
            {


                Debug.Log("Move through bottom door");
                GetComponent<PlayerMovement>().MinusAction();

                if (roomNumber == 0)
                {
                    Debug.Log("Move to Room 1");
                    roomArray[0].SetActive(false);
                    roomArray[1].SetActive(true);
                    roomNumber = 1;
                    transform.position = TOP;
                    movingThroughDoor = true;
                }

                else if (roomNumber == 1)
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

                else if (roomNumber == 5)
                {
                    Debug.Log("Move to Room 6");
                    roomArray[5].SetActive(false);
                    roomArray[6].SetActive(true);
                    transform.position = TOP;
                    roomNumber = 6;
                    movingThroughDoor = true;
                }

                else if (roomNumber == 6)
                {
                    Debug.Log("Move to Room 7");
                    roomArray[6].SetActive(false);
                    roomArray[7].SetActive(true);
                    transform.position = TOP;
                    roomNumber = 7;
                    movingThroughDoor = true;
                }

                else if (roomNumber == 3)
                {
                    Debug.Log("Move to Room 8");
                    roomArray[3].SetActive(false);
                    roomArray[8].SetActive(true);
                    transform.position = TOP;
                    roomNumber = 8;
                    movingThroughDoor = true;
                }

                else if (roomNumber == 8)
                {
                    Debug.Log("Move to Room 9");
                    roomArray[8].SetActive(false);
                    roomArray[9].SetActive(true);
                    transform.position = TOP;
                    roomNumber = 9;
                    movingThroughDoor = true;
                }

                else if (roomNumber == 4)
                {
                    Debug.Log("Move to Room 10");
                    roomArray[4].SetActive(false);
                    roomArray[10].SetActive(true);
                    transform.position = TOP;
                    roomNumber = 10;
                    movingThroughDoor = true;
                }

            }


            //Moving through left door
            if (Input.GetKeyDown(KeyCode.A) && other.tag == "LeftDoor")
            {
                Debug.Log("Move through left door");
                GetComponent<PlayerMovement>().MinusAction();


                if (roomNumber == 2)
                {
                    Debug.Log("Move to Room 3");
                    roomArray[2].SetActive(false);
                    roomArray[3].SetActive(true);
                    transform.position = RIGHT;
                    roomNumber = 3;
                    movingThroughDoor = true;
                }
                else if (roomNumber == 5)
                {
                    Debug.Log("Move to Room 2");
                    roomArray[5].SetActive(false);
                    roomArray[2].SetActive(true);
                    transform.position = RIGHT;
                    roomNumber = 2;
                    movingThroughDoor = true;
                }
                else if (roomNumber == 6)
                {
                    Debug.Log("Move to Room 4");
                    roomArray[6].SetActive(false);
                    roomArray[4].SetActive(true);
                    transform.position = RIGHT;
                    roomNumber = 4;
                    movingThroughDoor = true;
                }
                else if (roomNumber == 4)
                {
                    Debug.Log("Move to Room 8");
                    roomArray[4].SetActive(false);
                    roomArray[8].SetActive(true);
                    transform.position = RIGHT;
                    roomNumber = 8;
                    movingThroughDoor = true;
                }
                else if (roomNumber == 7)
                {
                    Debug.Log("Move to Room 10");
                    roomArray[7].SetActive(false);
                    roomArray[10].SetActive(true);
                    transform.position = RIGHT;
                    roomNumber = 10;
                    movingThroughDoor = true;
                }

            }


            //Moving through right door
            if (Input.GetKeyDown(KeyCode.D) && other.tag == "RightDoor")
            {
                Debug.Log("Move through right door");
                GetComponent<PlayerMovement>().MinusAction();

                if (roomNumber == 2)
                {
                    Debug.Log("Move to Room 5");
                    roomArray[2].SetActive(false);
                    roomArray[5].SetActive(true);
                    transform.position = LEFT;
                    roomNumber = 5;
                    movingThroughDoor = true;
                }
                else if (roomNumber == 3)
                {
                    Debug.Log("Move to Room 2");
                    roomArray[3].SetActive(false);
                    roomArray[2].SetActive(true);
                    transform.position = LEFT;
                    roomNumber = 2;
                    movingThroughDoor = true;
                }
                else if (roomNumber == 4)
                {
                    Debug.Log("Move to Room 6");
                    roomArray[4].SetActive(false);
                    roomArray[6].SetActive(true);
                    transform.position = LEFT;
                    roomNumber = 6;
                    movingThroughDoor = true;
                }
                else if (roomNumber == 8)
                {
                    Debug.Log("Move to Room 4");
                    roomArray[8].SetActive(false);
                    roomArray[4].SetActive(true);
                    transform.position = LEFT;
                    roomNumber = 4;
                    movingThroughDoor = true;
                }
                else if (roomNumber == 10)
                {
                    Debug.Log("Move to Room 7");
                    roomArray[10].SetActive(false);
                    roomArray[7].SetActive(true);
                    transform.position = LEFT;
                    roomNumber = 7;
                    movingThroughDoor = true;
                }

            }



            /* --------------------------------------------
             * PLAYER HAS REACHED EXIT OF SHIP
             ----------------------------------------------*/
            if (Input.GetKeyDown(KeyCode.S) && other.tag == "Exit")
            {
                Debug.Log("EXIT THE SHIP");
                SceneManager.LoadScene(2);
            }


            /*
             * IF HUMAN IS PICKED UP, OR IF ENEMY IS SACRIFICED
             */
            if (other.tag == "Human")
             {
                if(takeHuman == true)
                {
                    other.gameObject.SetActive(false);
                    takeHuman = false;
                }
             }

            if (other.tag == "Enemy")
            {
                if (sacrificedHuman == true)
                {
                    other.gameObject.SetActive(false);
                    sacrificedHuman = false;
                }
            }
            


        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
		triggered = true;
		this.otherTrigger = other;
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("OOF, hit an enemy!");
			OnEnemy = true;
        }

        if(other.gameObject.tag == "Human")
        {
            Debug.Log("YOU MET A HOOMAN");
			OnHuman = true;
        }

    }
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			OnEnemy = false;
		}
		if (other.gameObject.tag == "Human") {
			OnHuman = false;
		}
	}
	

    public void changeHumanCount(int n)
    {
        humanCount+=n;
    }

	public Dictionary<string, bool> getStatuses() {
		statuses["OnHuman"] = OnHuman;
		statuses["OnEnemy"] = OnEnemy;
		return statuses;
	}

	
}
