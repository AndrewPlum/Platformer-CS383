using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.TextCore.Text;

public class EntityAttackState : EntityState
{
    public override void EnterState(Entity entity)
    {
        Debug.Log("Trying Attack Animation");
        Animator animator = entity.GetComponent<Animator>();
        animator.runtimeAnimatorController = entity.Attack as RuntimeAnimatorController;

    }

    public override void UpdateState(Entity entity)
    {

    }

    public override void FixedUpdateState(Entity entity)
    {

    }

    public override void OnCollisionEnter(Entity entity)
    {

    }
}
