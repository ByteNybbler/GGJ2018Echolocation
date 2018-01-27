// Author(s): Paul Calande
// Creates a series of objects that moves outwards in a circle.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBurst : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The object to instantiate.")]
    GameObject obj;
    [SerializeField]
    [Tooltip("The number of objects to instantiate.")]
    int count;
    [SerializeField]
    [Tooltip("The speed at which the objects will move.")]
    float speed;
    [SerializeField]
    [Tooltip("The number of degrees to use in the burst.")]
    float spread;

    // Create the objects.
    // direction can be Vector2.up, or whatever direction the player is facing in.
    public void Burst(Vector2 direction)
    {
        float degreeDifference = spread / count;
        float degreesSoFar = degreeDifference * 0.5f;
        for (int i = 0; i < count; ++i)
        {
            GameObject newObj = GameObject.Instantiate(obj, transform.position, Quaternion.identity);
            Rigidbody2D rb = newObj.GetComponent<Rigidbody2D>();
            rb.velocity = Quaternion.AngleAxis(degreesSoFar, Vector3.forward) * direction * speed;
            degreesSoFar += degreeDifference;
        }
    }
}