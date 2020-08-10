using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New State", menuName = "AbilityData/Jump_Preparation")]
public class Jump_Preparation : StateData
{
    [Range(0.01f, 1.0f)]
    public float transitionTiming;
    public float jumpForceUp;
    public float jumpForceForward;
    public override void UpdateAbility(CharacterStateBase characterStateBase, Animator animator, AnimatorStateInfo stateInfo)
    {
        if (stateInfo.normalizedTime >= transitionTiming)
        {
            animator.SetBool("UpInTheAir", true);
        }
    }

    public override void OnEnter(CharacterStateBase characterStateBase, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharController controller = characterStateBase.getCharacterController(animator);
        Rigidbody charRB = controller.GetComponentInParent<Rigidbody>();
        if (charRB != null)
        {
            charRB.AddForce((Vector3.up * jumpForceUp + Vector3.forward * controller.getHorValue() * jumpForceForward), ForceMode.Impulse);
        }
    }

    public override void OnExit(CharacterStateBase characterStateBase, Animator animator, AnimatorStateInfo stateInfo)
    {
        
    }
}
