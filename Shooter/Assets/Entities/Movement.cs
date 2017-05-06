using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float rotationspeed = 500; 
	private Quaternion objectrotate;
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
		Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
		// if statement to stop the rotation to rotate back  when there no input, so that it will stay looking at the directino even thought  there no input
		//also  it can how much can it rotate with each input (sort of) and how fast it rotate (rotationspeed)
		if(input != Vector3.zero)
		{
			transform.rotation  = Quaternion.LookRotation (input);
			transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.x,objectrotate.eulerAngles.x,rotationspeed*Time.deltaTime);
		}
    }

}
