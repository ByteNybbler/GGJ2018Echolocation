// Author(s): Paul Calande
// End screen.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Reference to the time taken text.")]
    Text textTimeTaken;

    private void Awake()
    {
        textTimeTaken.text = "FINAL TIME: " + GlobalTimer.GetGlobalTimeString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneUtil.ExitGame();
        }
    }
}