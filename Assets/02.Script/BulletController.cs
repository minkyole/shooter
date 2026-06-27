using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float moveSpeed;
    public GameObject bulletImpact;
    public bool hurtPlayer;
    public GameObject explosionEffect;
    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x + (moveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<GameManager>().DropPowerUp(other.transform.position);
            FindObjectOfType<GameManager>().AddScore(other.gameObject.GetComponent<PointValue>().value);
            Instantiate(explosionEffect, other.gameObject.transform.position, other.gameObject.transform.rotation);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Player") && hurtPlayer.Equals(true))
        {
            FindObjectOfType<GameManager>().KillPlayer();
        }
        if (other.CompareTag("Shield"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("BossHandTop") && Boss1.canBeHurt)
        {
            FindObjectOfType<Boss1>().topHandHealth -= 1;
        }
        
        if (other.CompareTag("BossHandBottom") && Boss1.canBeHurt)
        {
            FindObjectOfType<Boss1>().bottomHandHealth -= 1;
        }
        if (other.CompareTag("BossMain") && Boss1.canBeHurt)
        {
            FindObjectOfType<Boss1>().mainHealth -= 1;
        }
        Instantiate(bulletImpact, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
