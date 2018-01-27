// Author(s): Paul Calande
// Fading light script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingLight : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Reference to the Light component.")]
    Light lightComponent;
    [SerializeField]
    [Tooltip("How many seconds the light takes to disappear.")]
    float fadeSeconds;

    [Tooltip("How quickly the light fades.")]
    float fadeSpeed;

    private void Start()
    {
        fadeSpeed = lightComponent.range / fadeSeconds;
    }

    private void Update()
    {
        float newRange = lightComponent.range - fadeSpeed * Time.deltaTime;
        if (newRange <= 0.0f)
        {
            Destroy(gameObject);
        }
        else
        {
            lightComponent.range = newRange;
        }
    }
}