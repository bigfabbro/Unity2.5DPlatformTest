using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New State", menuName = "AbilityData/Roll")]

public class Roll : StateData
{
    public float rollForce;
    public override void UpdateAbility(CharacterStateBase characterStateBase, Animator animator, AnimatorStateInfo stateInfo)
    {
        
    }

    public override void OnEnter(CharacterStateBase characterStateBase, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharController controller = characterStateBase.getCharacterController(animator);
        Rigidbody charRB = controller.GetComponentInParent<Rigidbody>();
        if (charRB != null)
        {
            float y_rotation = controller.GetComponentInParent<Transform>().rotation.eulerAngles.y;
            if (y_rotation  < 180)
            {
                charRB.AddForce((Vector3.forward * rollForce), ForceMode.Impulse);
            }
            else
            { 
                charRB.AddForce((Vector3.back * rollForce), ForceMode.Impulse);
            }
        }
    }

    public override void OnExit(CharacterStateBase characterStateBase, Animator animator, AnimatorStateInfo stateInfo)
    {
        animator.SetBool("IsRolling", false);
    }
}
