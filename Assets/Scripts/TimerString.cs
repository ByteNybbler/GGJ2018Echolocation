// Author(s): Paul Calande
// Component that converts a number of seconds into a "digital time" string.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerString : MonoBehaviour
{
    public string GetTimerString(float rawSeconds)
    {
        int seconds = Mathf.FloorToInt(rawSeconds);
        int secondsOnly = seconds % 60;
        int minutesOnly = seconds / 60;

        string result = "";
        result += AddZeroPadding(minutesOnly, 2);
        result += ":";
        result += AddZeroPadding(secondsOnly, 2);
        return result;
    }

    // Adds any 0s as padding if necessary.
    private string AddZeroPadding(int val, int stringLength)
    {
        string result = val.ToString();
        while (result.Length < stringLength)
        {
            result = "0" + result;
        }
        return result;
    }
}