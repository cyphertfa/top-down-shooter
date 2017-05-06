using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 velocity = new Vector2();

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        if (xAxis != 0)
        {
            velocity.x = 6f * xAxis;
        }
        else
        {
            velocity.x = 0;
        }

        if (yAxis != 0)
        {
            velocity.y = 6f * yAxis;
        }
        else
        {
            velocity.y = 0;
        }

        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.velocity = velocity;
    }
}
