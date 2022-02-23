using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManScript : MonoBehaviour
{
    Rigidbody2D rbman;
    public float speed;

    private void Awake() 
    {
        rbman = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.tag == "Player")
        {
            rbman.velocity = new Vector2(-speed, rbman.velocity.y);
        }    
    }
}
