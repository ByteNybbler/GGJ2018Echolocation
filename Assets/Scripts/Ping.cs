// Author(s): Paul Calande
// Ping script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ping : MonoBehaviour
{
    [SerializeField]
    [Tooltip("How many seconds the ping exists before getting destroyed.")]
    float lifetime;

    float secondsLived = 0.0f;

    private void Update()
    {
        secondsLived += Time.deltaTime;
        if (secondsLived > lifetime)
        {
            Destroy(gameObject);
        }
    }
}