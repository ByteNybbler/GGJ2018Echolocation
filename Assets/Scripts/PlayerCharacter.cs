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
    [Tooltip("Reference to the Shake component for the death animation.")]
    Shake shake;
    [SerializeField]
    [Tooltip("How many seconds it takes for the player character's sprite to explode upon dying.")]
    float secondsBeforeDeathExplosion;
    [SerializeField]
    [Tooltip("How many seconds it takes for the level to reset after dying.")]
    float secondsBeforeDeathRestart;
    [SerializeField]
    [Tooltip("Number of seconds between each death ping.")]
    float secondsBetweenDeathPings;
    [SerializeField]
    [Tooltip("Number of seconds between each dying sound effect.")]
    float secondsBetweenDeathNoises;
    [SerializeField]
    [Tooltip("Reference to the renderer.")]
    SpriteRenderer render;
    [SerializeField]
    [Tooltip("AudioSource to use for playing the ping sound effect.")]
    AudioSource audioSourcePing;
    [SerializeField]
    [Tooltip("AudioSource to use for the coin sound effect.")]
    AudioSource audioSourceCoin;
    [SerializeField]
    [Tooltip("AudioSource to use for the dying.")]
    AudioSource audioSourceDying;

    float secondsSinceLastPing = 0.0f;
    bool dying = false;
    float dyingSeconds = 0.0f;
    float secondsSinceDeathPing = 0.0f;
    float secondsSinceDeathNoise = 0.0f;

    private void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        if (inputHorizontal != 0.0f || inputVertical != 0.0f)
        {
            GlobalTimer.StartTimer();
        }

        if (dying)
        {
            //transform.RotateAround(transform.position, Vector3.forward, dyingSeconds);
            render.transform.Rotate(new Vector3(0.0f, 0.0f, dyingSeconds * dyingSeconds));
            shake.SetMagnitude(dyingSeconds * 0.01f);
            if (dyingSeconds > secondsBeforeDeathExplosion)
            {
                // Only proceed if the sprite is still visible.
                if (render.enabled)
                {
                    // Create the death explosion!
                    createBurst.SetSpread(360.0f);
                    createBurst.SetCount(200);
                    createBurst.Burst(Vector2.up);

                    // Disable the sprite renderer.
                    render.enabled = false;
                }
            }
            else
            {
                while (secondsSinceDeathPing > secondsBetweenDeathPings)
                {
                    createBurst.Burst(Random.insideUnitCircle.normalized);
                    secondsSinceDeathPing -= secondsBetweenDeathPings;
                }
                secondsSinceDeathPing += Time.deltaTime;
                if (secondsSinceDeathNoise > secondsBetweenDeathNoises)
                {
                    PlaySoundDying();
                    secondsSinceDeathNoise -= secondsBetweenDeathNoises;
                }
                //secondsSinceDeathNoise += Time.deltaTime;
                secondsSinceDeathNoise += dyingSeconds;
            }
            if (dyingSeconds > secondsBeforeDeathRestart)
            {
                // Restart the scene.
                SceneUtil.ResetScene();
            }
            dyingSeconds += Time.deltaTime;
        }
        else
        {
            //Vector2 move = new Vector2(inputHorizontal, inputVertical);
            Vector2 move = new Vector2(0.0f, inputVertical) * moveSpeed;

            float torque = -inputHorizontal * rotateSpeed;
            //Debug.Log(torque);
            rb.AddTorque(torque);
            rb.AddForce(transform.rotation * move);

            secondsSinceLastPing += Time.deltaTime;
            while (secondsSinceLastPing > secondsBetweenPings)
            {
                secondsSinceLastPing -= secondsBetweenPings;
                Burst();
            }
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
        if (!dying)
        {
            dying = true;
            RigidbodyUtil.StopRigidbody(rb);
            createBurst.SetCount(1);
            // Play sound effect.
            PlaySoundDying();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            Die();
            collision.gameObject.GetComponent<Spike>().Highlight();
        }
    }

    public void PlaySoundCoin()
    {
        audioSourceCoin.Play();
        //audioSourceCoin.PlayOneShot(audioSourceCoin.clip);
    }

    private void PlaySoundDying()
    {
        audioSourceDying.Play();
        //audioSourceDying.PlayOneShot(audioSourceDying.clip);
    }
}