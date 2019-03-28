using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotScript : MonoBehaviour {

    public PlayerController playerController;
    public Sprite originalSprite;
    public Sprite smashedSprite;

    private bool isSmashed;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private float potHealth;
    private float counter;

	// Use this for initialization
	void Start () {
        isSmashed = false;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        potHealth = 5;
        counter = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay2D(Collision2D other)
    {
        if (playerController == null || originalSprite == null || smashedSprite == null || animator == null || 
            spriteRenderer == null || boxCollider2D == null)
            return;

        if(other.gameObject.tag == "Player" && playerController.GetisAttacking() && !isSmashed)
        {
            counter -= Time.deltaTime;
            if(counter < 0)
            {
                animator.Play("Smashing");
                isSmashed = true;
                spriteRenderer.sprite = smashedSprite;
                boxCollider2D.isTrigger = true;
                counter = 1;
            }
        }
    }
}
