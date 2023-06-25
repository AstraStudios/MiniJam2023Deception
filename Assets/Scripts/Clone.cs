using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    [SerializeField] GameObject evilClone;
    public bool turnEvil = true;

    Collider2D collider_;
    SpriteRenderer renderer_;

    [SerializeField] float friendlyTime = 15f;
    private float timeCreatedAt;

    private bool dragging = false;

    private void Awake()
    {
        collider_ = GetComponent<Collider2D>();
        renderer_ = GetComponent<SpriteRenderer>();
        timeCreatedAt = Time.time;
    }

    private void Start()
    {
        // make only 20% turn evil
        if (turnEvil && Random.value >= .2)
            turnEvil = false;
    }

    private void Update()
    {
        if (dragging)
            friendlyTime += Time.deltaTime;

        // flash red
        renderer_.color = new Color(1, 1, 1);
        if (timeCreatedAt + friendlyTime - 3 <= Time.time && // 3 seconds left
            turnEvil &&
            Mathf.Floor(Time.time * 2 % 2) == 1) // red or not
        {
            renderer_.color = new Color(1, 0, 0);
        }

        // turn into evil clones
        if (timeCreatedAt + friendlyTime <= Time.time && turnEvil)
        {
            Instantiate(evilClone, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }

    public void StartDragging()
    {
        collider_.excludeLayers = LayerMask.GetMask("Player");
        dragging = true;
    }

    public void EndDragging()
    {
        collider_.excludeLayers = 0;
        dragging = false;
    }
}
