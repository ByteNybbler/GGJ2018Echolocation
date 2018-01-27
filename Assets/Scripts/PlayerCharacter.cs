// Author(s): Paul Calande
// Script for player character in Echolocation.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Reference to the Rigidbody component.")]
    Rigidbody2D rb;
    [SerializeField]
    [Tooltip("Reference to the CreateBurst component.")]
    CreateBurst createBurst;

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(moveHorizontal, moveVertical);

        rb.AddForce(move);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            createBurst.Burst();
        }
    }
}