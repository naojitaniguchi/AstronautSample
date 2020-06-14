using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxCameraFollow : MonoBehaviour
{
    public GameObject cameraObject;
    public float moveRate;
    Vector3 cameraPrevPos;
    // Start is called before the first frame update
    void Start()
    {
        cameraPrevPos = cameraObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraMoveDir = cameraObject.transform.position - cameraPrevPos;
        if ( cameraMoveDir.magnitude > 0.001f)
        {
            //Debug.Log(cameraMoveDir.magnitude);
            //Debug.Log(cameraMoveDir);
            gameObject.transform.position += cameraMoveDir * moveRate;
        }
        
        cameraPrevPos = cameraObject.transform.position;
    }
}
