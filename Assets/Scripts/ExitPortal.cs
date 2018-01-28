// Author(s): Paul Calande
// Exit portal script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPortal : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Reference to the Animator component.")]
    Animator animator;

    static int hashOpen = Animator.StringToHash("Open");

    bool isOpen = false;
    CoinController coinController;

    private void Awake()
    {
        coinController = FindObjectOfType<CoinController>();
        coinController.AllCoinsCollected += Open;
    }

    public void Open()
    {
        animator.SetTrigger(hashOpen);
        isOpen = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOpen)
        {
            if (collision.gameObject.tag == "Player")
            {
                //Debug.Log("Touched exit!");
                SceneUtil.LoadNextScene();
            }
        }
    }
}