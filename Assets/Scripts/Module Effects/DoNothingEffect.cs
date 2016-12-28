using UnityEngine;
using System.Collections;
using System;

public class DoNothingEffect : ModuleEffect
{
    public override void activateEffect()
    {
        Debug.Log("Module Has Do Nothing Effect");
    }

    public override void initEffect()
    {
        
    }

    public override void removeEffect()
    {
        
    }
}
