using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float horizontal;
    public Rigidbody2D rigidBody;
    private bool isFacingRight = true;

    [SerializeField]
    public float speed;

    [SerializeField]
    public float jumpingPower;

    //public Animator anim;
    public RuntimeAnimatorController Jump;
    public RuntimeAnimatorController WalkR;
    public RuntimeAnimatorController Idle;
    public RuntimeAnimatorController Dead;
    public RuntimeAnimatorController Attack;

    // public RuntimeAnimatorController MehrioIdle;
    // public RuntimeAnimatorController MehrioDead; 

    public EntityState currentState;
    public EntityIdleState idleState = new EntityIdleState();
    public EntityDeadState deadState = new EntityDeadState();
    public EntityJumpingState jumpingState = new EntityJumpingState();
    public EntityRunState runState = new EntityRunState();
    public EntityAttackState attackState = new EntityAttackState();

    // Start is called before the first frame update
    void Start()
    {
        currentState = idleState;

        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Flip the direction of the player depending on the which direction the player is moved.
    public void flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
