using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  DoorScript : MonoBehaviour {

    public bool isClosed;
    public Sprite doorOpenSprite;
    public Sprite doorClosedSprite;
    public PlayerController playerController;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private BoxCollider2D boxCollider2D;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();


        if (spriteRenderer == null || playerController == null)
            return;

		if(isClosed)
        {
            spriteRenderer.sprite = doorClosedSprite;
        }else
        {
            spriteRenderer.sprite = doorOpenSprite;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay2D(Collision2D other)
    {
        if (spriteRenderer == null || playerController == null)
            return;

        if (other.gameObject.tag == "Player")
        {
            if (playerController.GetIsGathering())
            {
                if (isClosed)
                {
                    animator.Play("Doors Opening");
                    spriteRenderer.sprite = doorOpenSprite;
                    StartCoroutine(ExecuteAfterTime(.5f, true));
                }
            }         
        }
    }

    private IEnumerator ExecuteAfterTime(float time, bool x) { 
        yield return new WaitForSeconds(time);
        boxCollider2D.isTrigger = x;
        isClosed = !x;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (spriteRenderer == null || playerController == null)
            return;

        if (other.gameObject.tag == "Player")
        {
            if (!isClosed)
            {
                animator.Play("Doors Closing");
                boxCollider2D.isTrigger = false;
                isClosed = true;
                spriteRenderer.sprite = doorClosedSprite;
                
            }
        }
    }

}
