// Author(s): Paul Calande
// Attaching this script to a GameObject guarantees that no GameObject of the same name will
// replace the old one when the scene is changed.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameBasedSingleton : MonoBehaviour
{
    private static HashSet<string> names = new HashSet<string>();

    private void Awake()
    {
        if (names.Contains(name))
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            names.Add(name);
        }
    }
}