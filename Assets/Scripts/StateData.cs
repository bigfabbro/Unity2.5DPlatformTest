using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateData : ScriptableObject
{
    public abstract void UpdateAbility(CharacterStateBase characterStateBase, Animator animator, AnimatorStateInfo stateInfo);
    public abstract void OnEnter(CharacterStateBase characterStateBase, Animator animator, AnimatorStateInfo stateInfo);
    public abstract void OnExit(CharacterStateBase characterStateBase, Animator animator, AnimatorStateInfo stateInfo);

}
