using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    Collider2D collider;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
    }

    public void StartDragging()
    {
        collider.excludeLayers = LayerMask.GetMask("Player");
    }

    public void EndDragging()
    {
        collider.excludeLayers = 0;
    }
}
