// Author(s): Paul Calande
// Coin script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collision: " + collision.name);
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collected a coin.");
            Destroy(transform.root.gameObject);
        }
    }
}