using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Sate", menuName = "AbilityData/MoveForward")]
public class MoveForward : StateData
{

    [SerializeField] private float Speed;
    public override void UpdateAbility(CharacterStateBase characterStateBase, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharController controller = characterStateBase.getCharacterController(animator);
        float hv = controller.getHorValue();
        
        animator.SetBool("IsRolling", controller.getRoll());
        animator.SetBool("IsJumping", controller.getJump());

        if (Math.Abs(hv) > 0)
        {
            animator.SetBool("IsRunning", controller.getRun());
            if (hv > 0)
            {
                controller.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (hv < 0)
            {
                controller.transform.transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            animator.SetBool("IsMoving", true);
            controller.transform.Translate(new Vector3(0, 0, Speed * Math.Abs(hv) * Time.deltaTime));
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    public override void OnEnter(CharacterStateBase characterStateBase, Animator animator, AnimatorStateInfo stateInfo)
    {
        
    }

    public override void OnExit(CharacterStateBase characterStateBase, Animator animator, AnimatorStateInfo stateInfo)
    {
       animator.SetBool("IsMoving", false);
    }
}
