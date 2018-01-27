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
        fadeSpeed = lightComponent.spotAngle / fadeSeconds;
    }

    private void Update()
    {
        float newValue = lightComponent.spotAngle - fadeSpeed * Time.deltaTime;
        if (newValue <= 0.0f)
        {
            //Debug.Log("Fading light destroyed.");
            Destroy(gameObject);
        }
        else
        {
            lightComponent.spotAngle = newValue;
        }
    }
}