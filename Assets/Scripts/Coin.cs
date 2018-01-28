// Author(s): Paul Calande
// Coin script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public delegate void CollectedHandler();
    public event CollectedHandler Collected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collision: " + collision.name);
        if (collision.gameObject.tag == "Player")
        {
            OnCollected();
        }
    }

    private void OnCollected()
    {
        Debug.Log("Collected a coin.");
        Destroy(transform.root.gameObject);
        if (Collected != null)
        {
            Collected();
        }
    }
}