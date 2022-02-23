using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform followTransform;
    public float xOffset;
    
    void FixedUpdate()
    {
        this.transform.position = new Vector3(followTransform.position.x + xOffset, this.transform.position.y, this.transform.position.z);  
    }
}
