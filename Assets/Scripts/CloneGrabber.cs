using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneGrabber : MonoBehaviour
{
    private GameObject grabed;
    private Rigidbody2D grabedRb;

    private Vector3 grabedOffset;

    private void Update()
    {
        // move to mouse pos
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mousePos;

        // start holding something
        if (Input.GetMouseButtonDown(0) && !grabed)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Clone"));

            if (hit)
            {
                grabed = hit.collider.gameObject;
                grabedRb = grabed.GetComponent<Rigidbody2D>();

                grabedOffset = grabed.transform.position - transform.position;
            }
        }

        // drop by deleting hinge
        if (Input.GetMouseButtonUp(0) && grabed)
        {
            grabed = null;
            grabedRb = null;
        }

        // move held object
        if (grabed)
        { 
            grabedRb.velocity = new Vector3(0, 0, 0);

            grabedRb.MovePosition((Vector3)mousePos + grabedOffset);
        }
    }
}
