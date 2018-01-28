// Author(s): Paul Calande
// Utility class for Rigidbodies.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyUtil : MonoBehaviour
{
    // Stops a Rigidbody in its tracks.
    public static void StopRigidbody(Rigidbody rb)
    {
        rb.constraints |= RigidbodyConstraints.FreezePosition;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
    public static void StopRigidbody(Rigidbody2D rb)
    {
        rb.constraints |= RigidbodyConstraints2D.FreezePosition;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0.0f;
    }
}