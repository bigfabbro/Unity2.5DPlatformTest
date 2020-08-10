using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New State", menuName = "AbilityData/Jump_Up")]
public class Jump_Up : StateData
{
    private float previousY;
    public override void UpdateAbility(CharacterStateBase characterStateBase, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharController controller = characterStateBase.getCharacterController(animator);
        if (previousY - controller.transform.position.y > 0)
        {
            animator.SetBool("Landing", true);
        }
    }

    public override void OnEnter(CharacterStateBase characterStateBase, Animator animator, AnimatorStateInfo stateInfo)
    {
        previousY = characterStateBase.getCharacterController(animator).transform.position.y;
    }

    public override void OnExit(CharacterStateBase characterStateBase, Animator animator, AnimatorStateInfo stateInfo)
    {
        animator.SetBool("UpInTheAir", false);
    }
}
