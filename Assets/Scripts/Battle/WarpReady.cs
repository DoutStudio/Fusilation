using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpReady : MonoBehaviour
{
    [HideInInspector]
    public int ShipsReadyForWarpIn = 0;
    public bool WarpIsReady = false;

    void Update()
    {
        if (ShipsReadyForWarpIn >= 2)
        {
            WarpIsReady = true;
            ShipsReadyForWarpIn = 2;
        }

        if (ShipsReadyForWarpIn <= 0)
        {
            WarpIsReady = false;
            ShipsReadyForWarpIn = 0;
        }
    }
}
