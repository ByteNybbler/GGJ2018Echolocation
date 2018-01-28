// Author(s): Paul Calande

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeViaGlobalTimer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("How many seconds the fade out takes.")]
    float fadeSeconds;
    [SerializeField]
    [Tooltip("Reference to the textMesh.")]
    TextMesh textMesh;

    float fadeSpeed;

    private void Awake()
    {
        fadeSpeed = 1 / fadeSeconds;
    }

    private void Update()
    {
        float alpha = 1 - GlobalTimer.GetGlobalTime() * fadeSpeed;
        Color col = textMesh.color;
        col.a = alpha;
        textMesh.color = col;
    }
}