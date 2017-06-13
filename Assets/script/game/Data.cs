using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{
    static private Vector3 position = Vector3.zero;

    static public Vector3 JoystickPosition
    {
        get
        {
            return position;
        }
        set
        {
            position = value;
        }
    }

}
