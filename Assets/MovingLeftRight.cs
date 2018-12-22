using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLeftRight : MonoBehaviour
{

    private Vector2 startPosition;
    private int speed;

    void Start()
    {
        startPosition = transform.position;
        speed = 32;
    }

    void FixedUpdate()
    {
        //FOR TOUCH SCREENS
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            float middle = Screen.width / 2;
            if (touch.position.x < middle && touch.phase == TouchPhase.Moved && transform.position.x > -2.8f) {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            else
            if (touch.position.x > middle && touch.phase == TouchPhase.Moved && transform.position.x < 7.0f)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }


        }
        else
        // DESKTOP WITH KEYBOARD CONTROLS
        {
            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -2.8f)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 7.0f)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
    }
}