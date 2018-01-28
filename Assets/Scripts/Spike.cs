// Author(s): Paul Calande
// Spike script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The sprite to use to highlight the spike upon death.")]
    Sprite spriteHighlighted;
    [SerializeField]
    [Tooltip("Reference to the renderer.")]
    SpriteRenderer render;

    public void Highlight()
    {
        render.sprite = spriteHighlighted;
    }
}