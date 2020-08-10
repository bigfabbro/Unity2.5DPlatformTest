using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualInput : MonoBehaviour
{
    private CharController charController;
    private void Awake()
    {
        charController = GetComponent<CharController>();
    }

    // Update is called once per frame
    void Update()
    {
        charController.setHorValue(InputManager.Instance.horValue);
        charController.setJump(InputManager.Instance.jump);
        charController.setRoll(InputManager.Instance.roll);
        charController.setRun(InputManager.Instance.run);
    }

}
