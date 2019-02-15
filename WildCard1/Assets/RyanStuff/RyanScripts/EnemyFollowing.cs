using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowing : MonoBehaviour
{
    public float speed;
    private Transform player;

    private Vector3 moveTo;

    public int moveDirection;

    List<int> moveList = new List<int>();
    public int[] moves;

    int DONT_MOVE = 0;
    int MOVE_LEFT = 1;
    int MOVE_RIGHT = 2;
    int MOVE_UP = 3;
    int MOVE_DOWN = 4;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        moveTo = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position != player.position+moveTo)
        transform.position = Vector3.MoveTowards(transform.position, moveTo, Time.deltaTime * speed);
    }

    public void MoveTowardsPlayer()
    {


        //if enemy is on right player
        if (player.position.x < transform.position.x)
        {
            moveList.Add(1);
        }

        //if enemy is on left of player
        if (player.position.x > transform.position.x)
        {
            moveList.Add(2);
        }

        //if enemy is above player
        if (player.position.y < transform.position.y)
        {
            moveList.Add(4);
        }

        //if enemy is below player
        if (player.position.y > transform.position.y)
        {
            moveList.Add(3);
        }

        //if enemy is on top of player
        if (player.position.x == transform.position.x && player.position.y == transform.position.y)
        {
            moveList.Add(0);
        }

        moveDirection = moveList[Random.Range(0, moveList.Count)];

        if (moveDirection == MOVE_RIGHT)
        {
            moveTo += new Vector3(1, 0, 0);
        }
        else if (moveDirection == MOVE_LEFT)
        {
            moveTo += new Vector3(-1, 0, 0);

        }
        else if (moveDirection == MOVE_UP)
        {
            moveTo += new Vector3(0, 1, 0);

        }
        else if (moveDirection == MOVE_DOWN)
        {
            moveTo += new Vector3(0, -1, 0);
        }
        else if (moveDirection == DONT_MOVE)
        {
            moveTo += new Vector3(0, 0, 0);
        }


        moveList.Clear();
    }
}
