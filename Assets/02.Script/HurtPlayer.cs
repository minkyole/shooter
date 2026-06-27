using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().KillPlayer();
            Destroy(gameObject);
        }
        if (other.CompareTag("Shield"))
        {
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
