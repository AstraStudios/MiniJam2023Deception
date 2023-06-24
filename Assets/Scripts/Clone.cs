using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    [SerializeField] GameObject evilClone;
    Collider2D _collider;

    [SerializeField] float friendlyTime = 15f;
    private float timeCreatedAt;

    private bool dragging = false;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        timeCreatedAt = Time.time;
    }

    private void Update()
    {
        if (dragging)
            friendlyTime += Time.deltaTime;

        if (timeCreatedAt + friendlyTime <= Time.time)
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
