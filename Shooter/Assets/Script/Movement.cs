using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float TurnSpeed = 500;
    public float MoveSpeed = 240;
    public float RunSpeed = 500;

    private Aim aim;
    // Use this for initialization
    void Start()
    {
        aim = GetComponent<Aim>();
    }

    // Update is called once per frame
    void Update()
    {


        Vector2 velocity = new Vector2();

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(xAxis, yAxis);
        direction.Normalize();
	
        velocity = direction * MoveSpeed * Time.deltaTime;

        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.velocity = velocity;

        //Jason, I have moved to code for detecting the angle between the player to the 'Aim' class
        transform.eulerAngles = Vector3.forward * Mathf.MoveTowardsAngle(transform.eulerAngles.z, aim.AimAngle, TurnSpeed * Time.deltaTime);
    }
	void LateUpdate () 
	{

		//sprinting with left shift
		if (Input.GetKey (KeyCode.LeftShift)) 
		{
			MoveSpeed = 500;

		}
		else  if (!Input.GetKey (KeyCode.LeftShift)) 
		{
			MoveSpeed = 240;

		}
	}

}
