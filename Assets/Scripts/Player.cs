using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{
    private bool isFacingRight = true;

    public Transform groundCheck;
    public LayerMask groundLayer;

    public Transform headCheck;
    public LayerMask brickLayer;
    public Health health;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    
    // Deal with the controls as well as the jumping of the character.
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && currentState != jumpingState && isGrounded())
        {
            audioSource.PlayOneShot(audioClip);
            currentState = jumpingState;
            currentState.EnterState(this);
        }

        flip();
        // Check if currentState is not null before calling UpdateState
        if (currentState != null)
        {
            currentState.UpdateState(this);
        } else {
            // Optionally, log an error or handle the case where currentState is null
            Debug.LogError("currentState is null! Ensure it's properly initialized.");
        }
        //ShowHealth();
    }

    // Move the player
    private void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
    }

    // Determine whether the player is touching the ground(or a brick) or not.
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer) || Physics2D.OverlapCircle(groundCheck.position, 0.2f, brickLayer);
    }

    // Determine whether the player colliders with a brick with its head.
    private bool isCollidingWithBrick()
    {
        return Physics2D.OverlapCircle(headCheck.position, 0.2f, brickLayer);
    }

    // Flip the direction of the player depending on the which direction the player is moved.
    private void flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    // Determine whether the player has come into contact with a brick from the bottom.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Brick" && isCollidingWithBrick())
        {
            Destroy(collision.gameObject);
        }
        currentState.OnCollisionEnter(this);
    }

    /*
    public void ShowHealth()
    {

        if (Input.GetKeyDown(KeyCode.H))
        {
            health.ShowHealth();
        }
    }
    */
}
