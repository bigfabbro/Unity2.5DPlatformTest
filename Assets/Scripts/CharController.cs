using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{

    private float horValue;
    private bool jump;
    private bool roll;
    private bool run;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getHorValue()
    {
        return horValue;
    }

    public void setHorValue(float hv)
    {
        horValue = hv;
    }

    public bool getJump()
    {
        return jump;
    }

    public void setJump(bool j)
    {
        jump = j;
    }

    public bool getRoll()
    {
        return roll;
    }

    public void setRoll(bool r)
    {
        roll = r;
    }
    
    public bool getRun()
    {
        return run;
    }

    public void setRun(bool r)
    {
        run = r;
    }
}
