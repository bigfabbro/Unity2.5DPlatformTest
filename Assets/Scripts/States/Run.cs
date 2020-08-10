using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New State", menuName = "AbilityData/Run")]
public class Run : StateData
{
    public float runSpeed;
    public override void UpdateAbility(CharacterStateBase characterStateBase, Animator animator,
        AnimatorStateInfo stateInfo)
    {
        CharController controller = characterStateBase.getCharacterController(animator);
        float hv = controller.getHorValue();
        if (Math.Abs(hv) > 0)
        {
            if (hv > 0)
            {
                controller.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (hv < 0)
            {
                controller.transform.transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            animator.SetBool("IsMoving", true);
            controller.transform.Translate(new Vector3(0, 0, runSpeed * Math.Abs(hv) * Time.deltaTime));
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
        animator.SetBool("IsRolling", controller.getRoll());
        animator.SetBool("IsRunning", controller.getRun());
    }

    public override void OnEnter(CharacterStateBase characterStateBase, Animator animator, AnimatorStateInfo stateInfo)
    {
    }

    public override void OnExit(CharacterStateBase characterStateBase, Animator animator, AnimatorStateInfo stateInfo)
    {
    }
}
