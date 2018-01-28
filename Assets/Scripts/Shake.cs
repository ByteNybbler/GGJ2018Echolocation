// Author(s): Paul Calande
// Makes an object shake about its local origin.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The magnitude of the shaking. Larger means more intense.")]
    float magnitude;

    private void Update()
    {
        float x = Random.Range(-magnitude, magnitude);
        float y = Random.Range(-magnitude, magnitude);
        float z = Random.Range(-magnitude, magnitude);
        transform.localPosition = new Vector3(x, y, z);
    }

    public void SetMagnitude(float newVal)
    {
        magnitude = newVal;
    }
}