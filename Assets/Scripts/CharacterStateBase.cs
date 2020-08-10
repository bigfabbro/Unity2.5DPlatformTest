using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateBase : StateMachineBehaviour
{
    
    public List<StateData> ListAbilityData = new List<StateData>();
    
    private CharController _playerController;

    public void UpdateAll(CharacterStateBase characterStateBase, Animator animator, AnimatorStateInfo stateInfo)
    {
        foreach (var stateData in ListAbilityData)
        {
            stateData.UpdateAbility(characterStateBase, animator, stateInfo);
        }
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (var stateData in ListAbilityData)
        {
            stateData.OnEnter(this, animator, stateInfo);
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        UpdateAll(this, animator, stateInfo);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (var stateData in ListAbilityData)
        {
            stateData.OnExit(this, animator, stateInfo);
        }
    }

    public CharController getCharacterController(Animator anim)
    {
        if (_playerController == null)
        {
            _playerController = anim.GetComponentInParent<CharController>();
        }

        return _playerController;
    }
}
