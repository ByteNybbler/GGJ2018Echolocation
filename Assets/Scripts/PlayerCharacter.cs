// Author(s): Paul Calande
// Script for player character in Echolocation.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Reference to the Rigidbody.")]
    Rigidbody2D rb;

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(moveHorizontal, moveVertical);

        rb.AddForce(move);
    }
}