using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forceScale = 0.1f ;
    public float MaxVelocity = 0.1f ;
    private bool mouseDown;
    private Vector3 mouseDownPos;

    // Start is called before the first frame update


    void Start()
    {
        mouseDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
            mouseDownPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
        }
        if (mouseDown)
        {
            //Debug.Log(Input.mousePosition);
            Vector3 dragVector = Input.mousePosition - mouseDownPos;
            //Debug.Log(dragVector);

            Vector2 forceVec;
            forceVec.x = dragVector.x;
            forceVec.y = dragVector.y;
            forceVec *= forceScale;

            gameObject.GetComponent<Rigidbody2D>().AddForce(forceVec);
            float velocityMagitude = gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
            if (velocityMagitude > MaxVelocity)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity.Normalize();
                gameObject.GetComponent<Rigidbody2D>().velocity *= MaxVelocity;
            }
        }


    }
}
