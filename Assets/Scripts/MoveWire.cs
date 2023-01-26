using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWire : MonoBehaviour
{
    private bool moving;
    private bool connected;

    private float startPosX;
    private float startPosY;

    private LineRenderer lr;

    public GameObject circuit1;
    public GameObject circuit2;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, circuit1.transform.position);
        lr.SetPosition(1, circuit2.transform.position);
    }

    void Update()
    {
        if (moving)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);



            Collider2D[] colliders = Physics2D.OverlapCircleAll(mousePos, .2f);
            foreach (Collider2D collider in colliders)
            {
                // make sure not my own collider
                if (collider.gameObject != gameObject && collider.transform.parent.name == "End Wire")
                {
                    circuit2 = collider.gameObject;

                    // update wire to the connection point position
                    lr.SetPosition(1, circuit2.transform.position);
                    connected = true;
                    return;
                }
            }

            lr.SetPosition(1, mousePos);
            connected = false;
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;
        if (connected == false)
        {
            lr.SetPosition(1, circuit1.transform.position);
        }
    }
}
