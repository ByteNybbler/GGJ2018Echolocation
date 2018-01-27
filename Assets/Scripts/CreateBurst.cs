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

    // Create the objects.
    public void Burst()
    {
        float degreeDifference = 360.0f / count;
        float degreesSoFar = 0.0f;
        for (int i = 0; i < count; ++i)
        {
            GameObject newObj = GameObject.Instantiate(obj, transform.position, Quaternion.identity);
            Rigidbody2D rb = newObj.GetComponent<Rigidbody2D>();
            rb.velocity = Quaternion.AngleAxis(degreesSoFar, Vector3.forward) * Vector2.up * speed;
            degreesSoFar += degreeDifference;
        }
    }
}