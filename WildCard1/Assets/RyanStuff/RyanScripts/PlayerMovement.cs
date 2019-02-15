using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int maxActions = 10;
    public int actionCount;

    public float speed;
    //How fast the player moves from one space to another

    public float moveDistance;
    //Can edit the moveDistance in the Unity editor to see how much
    //the player should move on a grid.

    private Vector3 pos;
    //Player's target position of where to move

    private Transform tr;

    //vertical and horizontal count make sure that player is within the boundaries
    //of the grid. They should be set to ZERO whenever the player is on the center tile.
    private int horizontalCount = 0;
    private int verticalCount = 0;

    public bool moveEnemy = false;

    // Start is called before the first frame update
    void Start()
    {
        actionCount = maxActions;
        pos = transform.position;
        tr = transform;

        
        
    }

    // Update is called once per frame
    void Update()
    {

        GameObject enemy = GameObject.Find("FollowingEnemy");
        EnemyFollowing followingEnemy = (EnemyFollowing)enemy.GetComponent(typeof(EnemyFollowing));

        //move RIGHT
        if (Input.GetKeyDown(KeyCode.D) && tr.position == pos)
            {
                //Only change position if it is within boundaries of the grid
                if (horizontalCount < 3)
                {
                    pos += new Vector3(moveDistance, 0, 0);
                    horizontalCount += 1;

                    followingEnemy.MoveTowardsPlayer();
                    
                    actionCount --;
                }

            }

            //move LEFT
            else if (Input.GetKeyDown(KeyCode.A) && tr.position == pos)
            {
                //Only change position if it is within boundaries of the grid
                if (horizontalCount > -3)
                {
                    pos += new Vector3(-moveDistance, 0, 0);
                    horizontalCount -= 1;

                    followingEnemy.MoveTowardsPlayer();

                    actionCount--;

                }
            }

            //move UP
            else if (Input.GetKeyDown(KeyCode.W) && tr.position == pos)
            {
                //Only change position if it is within boundaries of the grid
                if (verticalCount < 3)
                {
                    pos += new Vector3(0, moveDistance, 0);
                    verticalCount += 1;

                    followingEnemy.MoveTowardsPlayer();

                    actionCount --;

                }
            }

            //move DOWN
            else if (Input.GetKeyDown(KeyCode.S) && tr.position == pos)
            {
                //Only change position if it is within boundaries of the grid
                if (verticalCount > -3)
                {
                    pos += new Vector3(0, -moveDistance, 0);
                    verticalCount -= 1;

                    followingEnemy.MoveTowardsPlayer();

                    actionCount--;

                }
            }

        //What makes the player move to the designated target position (pos)
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);

    }

    public int GetMoveNumber(int n)
    {
        return n;
    }

    public void minusAction()
    {
        actionCount--;
    }

}
