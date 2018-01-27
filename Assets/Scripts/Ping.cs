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
    [SerializeField]
    [Tooltip("How many seconds to wait before the fade-out begins.")]
    float fadeOutDelaySeconds;
    [SerializeField]
    [Tooltip("How many seconds long the fade-out is.")]
    float fadeOutSeconds;
    /*
    [SerializeField]
    [Tooltip("The prefab to use for the light.")]
    GameObject prefabLight;
    */
    [SerializeField]
    [Tooltip("Reference to the rendering component.")]
    SpriteRenderer render;
    [SerializeField]
    [Tooltip("Reference to the rigidbody component.")]
    Rigidbody2D rb;

    bool fadingOut = false;
    float secondsLived = 0.0f;
    float fadeOutDelaySecondsPassed = 0.0f;
    float fadeOutSecondsPassed = 0.0f;

    private void Update()
    {
        if (secondsLived > lifetime)
        {
            Terminate();
        }
        secondsLived += Time.deltaTime;

        if (fadingOut)
        {
            if (fadeOutDelaySecondsPassed > fadeOutDelaySeconds)
            {
                float alpha = 1.0f - fadeOutSecondsPassed / fadeOutSeconds;
                Color col = render.color;
                col.a = alpha;
                render.color = col;
                if (fadeOutSecondsPassed > fadeOutSeconds)
                {
                    Destroy(gameObject);
                }
                else
                {
                    fadeOutSecondsPassed += Time.deltaTime;
                }
            }
            else
            {
                fadeOutDelaySecondsPassed += Time.deltaTime;
            }
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
        rb.constraints |= RigidbodyConstraints2D.FreezePosition;
        rb.velocity = Vector2.zero;
        fadingOut = true;
        //GameObject.Instantiate(prefabLight, transform.position + Vector3.back, Quaternion.identity);
        //Destroy(gameObject);
    }
}