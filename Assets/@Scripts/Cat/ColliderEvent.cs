using System;
using UnityEngine;

public class ColliderEvent : MonoBehaviour
{
    public GameObject fadeUI;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fadeUI.SetActive(true);
        }
    }
}