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
    [SerializeField]
    [Tooltip("How quickly the player rotates.")]
    float rotateSpeed;

    private void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        //Vector2 move = new Vector2(inputHorizontal, inputVertical);
        Vector2 move = new Vector2(0.0f, inputVertical);

        float torque = -inputHorizontal * rotateSpeed;
        //Debug.Log(torque);
        rb.AddTorque(torque);
        rb.AddForce(transform.rotation * move);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            createBurst.Burst(transform.up);
        }
    }
}