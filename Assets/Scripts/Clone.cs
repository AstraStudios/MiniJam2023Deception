using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    [SerializeField] GameObject evilClone;
    public bool turnEvil = true;

    Collider2D _collider;

    [SerializeField] float friendlyTime = 15f;
    private float timeCreatedAt;

    private bool dragging = false;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
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

        if (timeCreatedAt + friendlyTime <= Time.time && turnEvil)
        {
            Instantiate(evilClone, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }

    public void StartDragging()
    {
        _collider.excludeLayers = LayerMask.GetMask("Player");
        dragging = true;
    }

    public void EndDragging()
    {
        _collider.excludeLayers = 0;
        dragging = false;
    }
}
