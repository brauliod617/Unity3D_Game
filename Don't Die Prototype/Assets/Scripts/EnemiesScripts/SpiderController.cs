using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    public Transform target;
    public BoxCollider2D walkZone;
    public float waitTime;
    public float walkTime;
    public float moveSpeed;
    public int attackSpeed;

    private int walkDirectionInt;
    private bool hasWalkZone;
    private bool isAttacking;
    private bool isWalking;
    private float walkCounter;
    private Rigidbody2D rb2d;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;


    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        walkCounter = walkTime;
        isAttacking = false;
        ChooseDirection();
        if (walkZone != null )
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking) //regular movement around the map
        {
            Wander();
        }
    }

    private void OnTriggerStay2D(Collider2D other) //once player enters trigger, start attacking orders
    {
        if (other.gameObject.tag == "Player" && target != null)//if player enters collider zone
        {
            if (Vector2.Distance(transform.position, target.position) > 1f) //if distance of player and spider is > 1
            {
                //Lerp the spiders position towards the players position
                transform.position = Vector2.Lerp(transform.position, target.position, (attackSpeed) * Time.deltaTime);
            }
            isAttacking = true; //used to stop udate from calling wander()


        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //if player leaves collider zone
        if (other.gameObject.tag == "Player")
            isAttacking = false;//tell update to resume wander()
    }

    public void ChooseDirection() //function used to change the walking direction
    {
        walkDirectionInt = Random.Range(0, 4);//generates random int 0-3, int represents NEWS positions
        isWalking = true;
        walkCounter = walkTime; //initiate walk Counter
    }

    void Wander()//used to make spider wander around the map
    {
        if (isWalking && rb2d != null) // if spider is walking
        {
            switch (walkDirectionInt) //based on random int we decide which directo to walk
            {
                case 0://all of these will only run if a walkzone is placed in unity editor Inspector
                    //if we cross to max North position
                    if (hasWalkZone && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false; //say we aint walking
                        break; // leave this switch statement stop walking
                    }
                    rb2d.velocity = new Vector2(0, moveSpeed); //else if we havent crossed North point and we are moving north, ad velocity at moveSpeed to North
                    break;
                case 1:
                    if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        break;
                    }
                    rb2d.velocity = new Vector2(moveSpeed, 0);
                    break;
                case 2:
                    if (hasWalkZone && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        break;
                    }
                    rb2d.velocity = new Vector2(0, -moveSpeed);
                    break;
                case 3:
                    if (hasWalkZone && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        break;
                    }
                    rb2d.velocity = new Vector2(-moveSpeed, 0);
                    break;
            }
            walkCounter -= Time.deltaTime; //decrement walkCounter
            if (walkCounter < 0)
            {
                isWalking = false;
                walkCounter = waitTime;
            }
        }
        else //if not walking
        {
            walkCounter -= Time.deltaTime; //decrement walk counter
            if(rb2d != null)
                rb2d.velocity = Vector2.zero; // stop spider from moving
            if (walkCounter < 0) //once counter becomes < 0
            {
                ChooseDirection(); //restart walking by choosing direction
            }
        }
 
    }

}
