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
    [Tooltip("How quickly the player moves.")]
    float moveSpeed;
    [SerializeField]
    [Tooltip("How quickly the player rotates.")]
    float rotateSpeed;
    [SerializeField]
    [Tooltip("Number of seconds between each ping.")]
    float secondsBetweenPings;
    [SerializeField]
    [Tooltip("AudioSource to use for playing the ping sound effect.")]
    AudioSource audioSourcePing;

    float secondsSinceLastPing = 0.0f;

    private void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        //Vector2 move = new Vector2(inputHorizontal, inputVertical);
        Vector2 move = new Vector2(0.0f, inputVertical) * moveSpeed;

        float torque = -inputHorizontal * rotateSpeed;
        //Debug.Log(torque);
        rb.AddTorque(torque);
        rb.AddForce(transform.rotation * move);

        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Burst();
        }
        */

        secondsSinceLastPing += Time.deltaTime;
        while (secondsSinceLastPing > secondsBetweenPings)
        {
            secondsSinceLastPing -= secondsBetweenPings;
            Burst();
        }
    }

    // Ping!
    private void Burst()
    {
        createBurst.Burst(transform.up);
        audioSourcePing.Play();
    }

    private void Die()
    {
        // TODO
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision!");
        Debug.Log(other.gameObject.name);
    }
}