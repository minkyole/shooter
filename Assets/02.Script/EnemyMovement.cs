using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeedX;
    public float moveSpeedY;

    private Rigidbody2D rb;

    public float XTarget;
    public float YTarget;
    public int moveType;
    public bool moveUp;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        switch (moveType)
        {
            case 0:
                if (transform.position.x < XTarget)
                {
                    rb.velocity = new Vector2(-moveSpeedX, -moveSpeedY);
                }
                else
                {
                    rb.velocity = new Vector2(-moveSpeedX, 0f);
                }
                break;

            case 1:
                if (transform.position.x < XTarget)
                {
                    rb.velocity = new Vector2(-moveSpeedX, moveSpeedY);
                }
                else
                {
                    rb.velocity = new Vector2(-moveSpeedX, 0f);
                }
                break;

            case 2:
                if (transform.position.x < XTarget)
                {
                    if (moveUp)
                    {
                        if (transform.position.y > YTarget)
                        {
                            rb.velocity = new Vector2(-moveSpeedX, 0f);
                        }
                        else
                        {
                            rb.velocity = new Vector2(-moveSpeedX, moveSpeedY);
                        }
                    }
                    else
                    {
                        if (transform.position.y < YTarget)
                        {
                            rb.velocity = new Vector2(-moveSpeedX, 0f);
                        }
                        else
                        {
                            rb.velocity = new Vector2(-moveSpeedX, -moveSpeedY);
                        }
                    }
                }
                else
                {
                    rb.velocity = new Vector2(-moveSpeedX, 0f);
                }
                break;
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
