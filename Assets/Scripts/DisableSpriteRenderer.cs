// Author(s): Paul Calande
// Disables SpriteRenderer on Awake.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSpriteRenderer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Reference to the rendering component.")]
    SpriteRenderer render;

    private void Start()
    {
        render.enabled = false;
    }
}