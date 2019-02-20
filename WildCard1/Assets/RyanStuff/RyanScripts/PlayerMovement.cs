using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int maxActions = 10;
    public int actionCount;


    // Start is called before the first frame update
    void Start()
    {
        actionCount = maxActions;
    }

    // Update is called once per frame
    void Update()
    {

       
        //move RIGHT
        if (Input.GetKeyDown(KeyCode.D) && transform.position.x < -0.5)
        {
            actionCount--;
            transform.position = new Vector3(transform.position.x + 1, transform.position.y);

            //When player moves through a door, it does two actions, which is not supposed to happen.
            //The if statements like this one are what "reset" the moves so that it seems like
            //only one action is made, which is correct.
            if (GetComponent<PlayerInteraction>().movingThroughDoor)
            {
                transform.position = new Vector3(transform.position.x - 1, transform.position.y);
                GetComponent<PlayerInteraction>().movingThroughDoor = false;
                actionCount++;
            }
        }

        //move LEFT
        else if (Input.GetKeyDown(KeyCode.A) && transform.position.x > -6.5)
        {
            actionCount--;
            transform.position = new Vector3(transform.position.x - 1, transform.position.y);

            if (GetComponent<PlayerInteraction>().movingThroughDoor)
            {
                transform.position = new Vector3(transform.position.x + 1, transform.position.y);
                GetComponent<PlayerInteraction>().movingThroughDoor = false;
                actionCount++;
            }
        }

        //move UP
        else if (Input.GetKeyDown(KeyCode.W) && transform.position.y < 3)
        {
            actionCount--;
            transform.position = new Vector3(transform.position.x, transform.position.y + 1);

            if (GetComponent<PlayerInteraction>().movingThroughDoor)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 1);
                GetComponent<PlayerInteraction>().movingThroughDoor = false;
                actionCount++;
            }
        }

        //move DOWN
        else if (Input.GetKeyDown(KeyCode.S) && transform.position.y > -3)
        {
            actionCount--;
            transform.position = new Vector3(transform.position.x, transform.position.y -1);

            if(GetComponent<PlayerInteraction>().movingThroughDoor)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 1);
                GetComponent<PlayerInteraction>().movingThroughDoor = false;
                actionCount++;
            }
                
        }
        

    }

    public int GetMoveNumber()
    {
        return actionCount;
    }

    public void MinusAction()
    {
        actionCount--;
    }

}
