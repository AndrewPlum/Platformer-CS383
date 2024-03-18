using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public GameObject player; // will assign dynamically at runtime by EnemyManager.cs
    public float distance; 

    /*
    // Set range of movement
    [Header ("Enemy Bounds")]
    [SerializeField]private Transform leftEdge;
    [SerializeField]private Transform rightEdge;
    // Will add later if time
    //*/

    [Header ("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement Parameters")]
    //[SerializeField] private float speed;         // now a part of entity class
    private Vector3 initScale;
    private bool movingLeft;
    private bool playerDirection;

    [Header("Idle Behavior")]
    [SerializeField]private float idleDuration;
    private float idleTimer;

    private void Awake(){
        initScale = enemy.localScale;
    }

    private void FixedUpdate(){
        distance = Vector2.Distance(transform.position,player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        
        if (distance < 10){
            transform.position = Vector2.MoveTowards(this.transform.position,player.transform.position, speed*Time.deltaTime);

            if (distance > 2)       // set correct horizontal when chasing player
            {
                if (playerDirection = Vector2.Dot(player.transform.position - transform.position, transform.right) > 0)
                {
                    horizontal = -1f;
                }
                else
                {
                    horizontal = 1f;
                }
            }
            else
            {
                if ( (currentState != attackState) && (currentState != deadState) )     // attack player when within range
                {
                    horizontal = 0f;
                    currentState = attackState;
                    currentState.EnterState(this);
                }
            }
        }
        else
        {
            horizontal = 0f;
        }

        flip();
        // Check if currentState is not null before calling UpdateState
        if (currentState != null)
        {
            currentState.UpdateState(this);
        }
        else
        {
            // Optionally, log an error or handle the case where currentState is null
            Debug.LogError("currentState is null! Ensure it's properly initialized.");
        }
        /*
        // Set range of enemy movement
        if(movingLeft){
            if(enemy.position.x >= leftEdge.position.x){
                MoveInDirection(-1);
            }else{
                DirectionChange();
            }
        }else{
            if(enemy.position.x <= rightEdge.position.x){
                MoveInDirection(1);
            }else{
                DirectionChange();
            }
        }
        //*/
    }

    private void DirectionChange(){

        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration){
            movingLeft = !movingLeft;
        }
    }

    private void MoveInDirection(int _direction){
        idleTimer=0;

        enemy.localScale = new Vector3(Mathf.Abs(initScale.x)*_direction,initScale.y,initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime *_direction*speed,enemy.position.y,enemy.position.z);
    }

    // trigger death state animation
    public void ToDeathState()
    {
        //Destroy(gameObject.GetComponent<Collider>());
        currentState = deadState;
        currentState.EnterState(this);
    }

    // deletes enemy gameObject
    public void deleteEnemy()
    {
        Destroy(gameObject);
    }
}
