using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
 {
    private bool isIdle;
    private bool isAttacking;
    private bool isGathering;
    private bool menuIsActive;

    private PlayerInvetory playerInvetory;
    private Rigidbody2D rb2d;
    private Vector2 idlePosition;   //gets start position which is idle

    public float playerSpeed;
    private Animator animator;


	// Use this for initialization
	void Start () 
    {
        playerInvetory = GetComponent<PlayerInvetory>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (playerInvetory == null || rb2d == null || animator == null)
            return;

        isIdle = true;  //set player idle beginning of game
        isGathering = false;
        menuIsActive = false;

        animator.SetBool("isIdle", true); //set player idle at beginning of game

        //set idlePosition equal to current position which is idle and not moving
        idlePosition = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        isAttacking = false;

	}

    /**************************************************************Update Functions**************************************************************/
    void Update ()
    {
        if (!menuIsActive) //if user is not inside menu
        {   
            handleMovement();
            handleSwordAttack();
            handleResourceGathering();
        }
        else //if user is in menu
        {   //stop player and change to idle animation
            rb2d.velocity = Vector2.zero;
            rb2d.angularVelocity = 0f;
            updateAnimation(0, 0, idlePosition);
        }
    }



    /**************************************************************Handler Functions***************************************************/

    void handleResourceGathering() { isGathering = Input.GetButton("Space"); }

    void handleSwordAttack(){
        if(animator != null)
            animator.SetBool("isFire1", Input.GetButton("Fire1"));
        isAttacking = Input.GetButton("Fire1");
    }

    void handleMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        if (rb2d == null)
            return;

        rb2d.AddForce(movement * playerSpeed);
        rb2d.velocity = movement * 5;

        updateAnimation(moveHorizontal, moveVertical, movement);
    }


    /**************************************************************Getters/Setters***************************************************/

    public PlayerInvetory GetPlayerInvetory() { return playerInvetory; }
    public bool GetIsAttackting() { return isAttacking; }
    public bool GetIsGathering() { return isGathering; }
    public bool GetisAttacking() { return isAttacking; }
    public void SetMenuIsActive(bool isActive) { menuIsActive = isActive; }

    /**************************************************************Receiver Functions************************************************/

    void ReceiveFruit(int fruitAmount)
    {
        if (isGathering && playerInvetory != null)
            playerInvetory.AddToFruitAmount(fruitAmount);
    }

    void ReceiveWood(int woodAmount)
    {
        if (isGathering && playerInvetory != null) //FIXME:inefficient, checking isGathering here and in messageSender
            playerInvetory.AddToWoodAmount(woodAmount);
    }

    /*************************************************************Animation Function***************************************************/

    void updateAnimation(float moveHorizontal, float moveVertical, Vector2 movement)
    {
        if (animator == null)
        {
            print("Error in PlayerController118\n");
            return;
        }

        if (idlePosition == movement)
        {  //check if player is moving 
            isIdle = true;
            animator.SetBool("isIdle", true);
        }
        else
        {
            isIdle = false;
            animator.SetBool("isIdle", false);
        }
        if (moveVertical > 0 && !isIdle)
        { //check if moving up
            animator.SetInteger("movingDirection", 0);
        }
        else if (moveVertical < 0 && !isIdle)
        {//if moving down
            animator.SetInteger("movingDirection", 1);
        }
        else if (moveHorizontal < 0 && !isIdle)
        { //if moving left
            animator.SetInteger("movingDirection", 2);
        }
        else if (moveHorizontal > 0 && !isIdle)
        { //if moving right
            animator.SetInteger("movingDirection", 3);
        }
    }//end of updateAnimation
}//end of playerController class
