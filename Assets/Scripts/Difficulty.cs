using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty 
{
    public static float maxDifficultySecs = 60f;

    public static float GetDifficulty()
    {        
        return Mathf.Clamp01(Time.timeSinceLevelLoad/maxDifficultySecs);
    }
}