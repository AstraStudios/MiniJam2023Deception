using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float movementSpeed;
    Transform player;

    Rigidbody2D rb;
    SpriteRenderer renderer_;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer_ = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (transform.position - player.position).normalized;

        rb.MovePosition(transform.position - direction * movementSpeed);

        renderer_.flipX = direction.x >= 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            player.GetComponent<Player>().Death();

            Destroy(gameObject);
        }
    }
}
