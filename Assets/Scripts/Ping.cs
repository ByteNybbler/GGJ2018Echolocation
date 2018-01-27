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
    /*
    [SerializeField]
    [Tooltip("The prefab to use for the light.")]
    GameObject prefabLight;
    */

    float secondsLived = 0.0f;

    private void Update()
    {
        secondsLived += Time.deltaTime;
        if (secondsLived > lifetime)
        {
            Terminate();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        foreach (ContactPoint2D cp in collision.contacts)
        {
            Vector2 normal = cp.normal;
        }
        */
        Terminate();
    }

    private void Terminate()
    {
        //GameObject.Instantiate(prefabLight, transform.position + Vector3.back, Quaternion.identity);
        Destroy(gameObject);
    }
}