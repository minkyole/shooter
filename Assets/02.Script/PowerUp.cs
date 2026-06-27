using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool isShield;
    public bool isSpeed;
    public bool isDouble;
    public bool isExtraLife;

    public float moveSpeed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isShield)
            {
                other.gameObject.GetComponent<PlayerController>().shield.SetActive(true);
                Destroy(gameObject);
            }
            if (isSpeed)
            {
                FindObjectOfType<GameManager>().ActivateSpeedPower();
                Destroy(gameObject);
            }
            if (isDouble)
            {
                other.gameObject.GetComponent<PlayerController>().doubleShot = true;
                Destroy(gameObject);
            }
            if (isExtraLife)
            {
                FindObjectOfType<GameManager>().AddLife();
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x - (moveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
    }
}
