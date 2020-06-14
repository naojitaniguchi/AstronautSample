using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject player;
    public float xDistanceMax = 0.3f;
    public float yDistanceMax = 0.3f;
    public float followSpeedRate = 0.8f;
    public float followFrames = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xDistance = player.transform.position.x - gameObject.transform.position.x;
        float yDistance = player.transform.position.y - gameObject.transform.position.y;
        float xPos = gameObject.transform.position.x;
        float yPos = gameObject.transform.position.y;
        bool moveFlag = false;
        if (Math.Abs(xDistance) >= xDistanceMax)
        {
            if (xDistance > 0.0f ) {
                xPos = player.transform.position.x - xDistanceMax;
            }
            else
            {
                xPos = player.transform.position.x + xDistanceMax;
            }
            moveFlag = true;
        }
        if (Math.Abs(yDistance) >= yDistanceMax)
        {
            if (yDistance > 0.0f)
            {
                yPos = player.transform.position.y - yDistanceMax;
            }
            else
            {
                yPos = player.transform.position.y + yDistanceMax;
            }
            moveFlag = true;
        }
        if ( moveFlag)
        {
            Vector3 targetPos = new Vector3(xPos, yPos, gameObject.transform.position.z);
            Vector3 moveVec = targetPos - gameObject.transform.position;
            float speed = moveVec.magnitude / followFrames;

            //Debug.Log(speed);

            gameObject.transform.position += moveVec * speed  * Time.deltaTime;
        }
    }
}
