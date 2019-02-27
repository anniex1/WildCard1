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

    public PlayerMovement PlayerMovementScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public void MoveTowardsPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

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
            transform.position = new Vector3(transform.position.x + 1, transform.position.y);
        }
        else if (moveDirection == MOVE_LEFT)
        {
            transform.position = new Vector3(transform.position.x - 1, transform.position.y);

        }
        else if (moveDirection == MOVE_UP)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1);

        }
        else if (moveDirection == MOVE_DOWN)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1);
        }
        else if (moveDirection == DONT_MOVE)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y);
        }


        moveList.Clear();
    }

    public IEnumerator MoveOneSpace()
    {
        yield return new WaitForSeconds(.25f);
        MoveTowardsPlayer();

        GameObject.Find("Player").GetComponent<PlayerTurn>().enemyMoving = false;
    }

    public IEnumerator MoveTwoSpaces()
    {
        for (int i = 0; i < 2; i++)
        {
            MoveTowardsPlayer();
            yield return new WaitForSeconds(.25f);
        }

        GameObject.Find("Player").GetComponent<PlayerTurn>().enemyMoving = false;
    }

}
