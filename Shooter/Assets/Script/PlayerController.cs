using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to control a player object via mouse,keyboard and joypad inputs.
/// </summary>
[RequireComponent(typeof(Movement), typeof(Aim), typeof(Weapon))]
public class PlayerController : MonoBehaviour {

    private bool isUsingMouse = true;

    Movement movement;
    Aim aim;
    Weapon weapon;

	// Use this for initialization
	void Start () {
        movement = GetComponent<Movement>();
        aim = GetComponent<Aim>();
        weapon = GetComponent<Weapon>();
	}
	
	// Update is called once per frame
	void Update () {
        //Get movement direction
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(xAxis, yAxis);
        direction.Normalize();
        //Check if sprinting
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);

        //Push state to movement object.
        movement.SetMovement(direction, isSprinting);

        //Get aiming direction
        if (isUsingMouse)
        {
            aim.AimDegrees = GetMouseAngle();
        }
        else
        {
            aim.AimDegrees = GetJoypadAngle();
        }

        //Determine if player is trying to fire.
        if(Input.GetButton("Fire1"))
        {
            weapon.Shoot();
        }

        if(Input.GetButton("Fire2"))
        {
            weapon.Reload();
        }
        
    }

    /// <summary>
    /// Retreives the angle in degrees of the mouse from the center of the screen.
    /// </summary>
    /// <returns>Angle in degrees.</returns>
    public float GetMouseAngle()
    {
        Vector3 mousePosition = Input.mousePosition;
        //make 0,0 screen center.
        mousePosition -= new Vector3(Screen.width / 2, Screen.height / 2, 0);

        return Mathf.Atan2(mousePosition.y, mousePosition.x) * 180f / Mathf.PI;
    }

    /// <summary>
    /// Retreives the angle in degrees of the right analog stick.
    /// </summary>
    /// <returns>Angle in degrees.</returns>
    public float GetJoypadAngle()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        //If there is no input on the joystick then remain facing in the current direction.
        return Mathf.Atan2(input.y, input.x) * 180f / Mathf.PI;
    }
}
