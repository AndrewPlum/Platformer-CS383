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

    public Transform attackPoint;
    public LayerMask enemyLayer;
    [SerializeField] private float radius;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    // Deal with the controls, jumping, and attacking of the character.
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && currentState != jumpingState && isGrounded())
        {
            audioSource.PlayOneShot(audioClip);
            currentState = jumpingState;
            currentState.EnterState(this);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            currentState = attackState;
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

    // return to idle state
    private void ReturnIdleState()
    {
        currentState = idleState;
        currentState.EnterState(this);
    }

    // deletes enemies in range of attack
    public void Attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.position, radius, enemyLayer);

        foreach (Collider2D enemyGameObject in enemy)
        {
            //Debug.Log("Hit enemy with sword");
            Destroy(enemyGameObject.gameObject);
        }
    }

    // for visualizing attack circle
    /*private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }*/
}
