using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
   




    private Vector3 initialPosition;

    private Vector2 mousePosition;

    private float deltaX, deltaY;



    private void start()
    {
        initialPosition = transform.position;
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse PositionX: "+ Input.mousePosition.x+ " Mouse PositionY: " + Input.mousePosition.y);
           // deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            //deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;

    }

    private void OnMouseDrag()
    {

            //mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           // transform.position = new Vector3(mousePosition.x - deltaX,transform.position.y, mousePosition.y - deltaY);

    }




}
