using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticScript
{
    private static int humCount;

    public static int HumCount
    {
        get
        {
            return humCount;
        }
        set
        {
            humCount = value;
        }
    }

}
