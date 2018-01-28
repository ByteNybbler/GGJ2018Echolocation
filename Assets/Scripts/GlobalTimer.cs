// Author(s): Paul Calande
// Disgusting global/static garbage. Game Jams demand desperate measures.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalTimer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Reference to the timer text.")]
    Text textTimer;
    [SerializeField]
    [Tooltip("Reference to the TimerString component to use.")]
    TimerString timerString;

    private static float globalTime = 0.0f;
    private static string globalTimeString = "";
    private static bool started = false;

    private void Awake()
    {
        UpdateGlobalTimeString();
    }

    private void Update()
    {
        if (started)
        {
            globalTime += Time.deltaTime;
        }
        UpdateGlobalTimeString();
    }

    private void UpdateGlobalTimeString()
    {
        globalTimeString = timerString.GetTimerString(globalTime);
        textTimer.text = globalTimeString;
    }

    public static string GetGlobalTimeString()
    {
        return globalTimeString;
    }

    public static float GetGlobalTime()
    {
        return globalTime;
    }

    public static void StartTimer()
    {
        started = true;
    }
}