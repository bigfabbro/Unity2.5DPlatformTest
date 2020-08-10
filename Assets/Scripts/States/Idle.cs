using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New State", menuName = "AbilityData/Idle")]
public class Idle : StateData
{
    public override void UpdateAbility(CharacterStateBase characterStateBase, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharController controller = characterStateBase.getCharacterController(animator);
        float hv = controller.getHorValue();
        
        animator.SetBool("IsJumping", controller.getJump());
        animator.SetBool("IsRolling", controller.getRoll());
        
        if (Math.Abs(hv) > 0)
        {
            animator.SetBool("IsMoving", true);
            animator.SetBool("IsRunning", controller.getRun());
        }
    }
    
    public override void OnEnter(CharacterStateBase characterStateBase, Animator animator, AnimatorStateInfo stateInfo)
    {
        
    }

    public override void OnExit(CharacterStateBase characterStateBase, Animator animator, AnimatorStateInfo stateInfo)
    {
        
    }
}
