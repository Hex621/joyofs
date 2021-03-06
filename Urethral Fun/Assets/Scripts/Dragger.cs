using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour
{
    private Vector2 dragOffset;
    private Camera cam;
    [SerializeField] private float speed = 10;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void OnMouseDown()
    {
        dragOffset = new Vector2(transform.position.x, transform.position.y) - GetMousePos();
    }
    private void OnMouseDrag()
    {
        Vector2 stuff = GetMousePos() + dragOffset;
        this.GetComponent<Rigidbody2D>().MovePosition(stuff);
        //this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        //Rotate();


    }

    Vector2 GetMousePos()
    {
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
    void Update()
    {
       
        
        
    }
    private void Rotate()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.root.Rotate(Vector3.forward * 4f, Space.Self);
            //Debug.Log(transform.parent.name);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.root.Rotate(Vector3.back * 4f, Space.Self);
        }
    }
}
