using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PinchDirection
{
    None, In, Out
}


public class PinchDetector : MonoBehaviour
{
    public static PinchDirection DetectPinch(Touch startT1, Touch startT2, Touch endT1, Touch endT2)
    {
        if (startT1.position.y != endT1.position.y && startT2.position.y != endT2.position.y)
        {
            if (startT1.position.y < endT1.position.y || startT2.position.y < endT1.position.y)
            {
                return PinchDirection.Out;
            }

            return PinchDirection.In;
        }
        else
        {
            return PinchDirection.None;
        }
    }
}
