using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPoint;
    public float shotDelay;
    private float shotCounter;
    void Start()
    {
        shotCounter = shotDelay;
    }

    void Update()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
            shotCounter = shotDelay;
        }
    }
}
