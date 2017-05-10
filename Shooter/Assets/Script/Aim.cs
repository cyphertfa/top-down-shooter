using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Determines the angle this game object is aiming at.
/// At 0 degrees, Y faces upwards, X faces rightward.
/// </summary>
public class Aim : MonoBehaviour {

    /// <summary>
    /// Get the angle this GameObject is aiming towards.
    /// At 0 degrees, Y faces upwards, X faces rightward.
    /// </summary>
    public float AimAngle { get
        {
            return aimAngle;
        }
    }

    public Vector2 AimVector
    {
        get
        {
            return new Vector2(Mathf.Cos(AimAngle*Mathf.Deg2Rad), Mathf.Sin(AimAngle*Mathf.Deg2Rad)); 
        }
    }

    private bool isUsingMouse = true;

    private float aimAngle;

	// Use this for initialization
	void Start () {
        aimAngle = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
        //TODO: How to determine a joystick or mouse is in use, and switch between modes.

        if(isUsingMouse)
        {
            aimAngle = GetMouseAngle() ;
        }
        else
        {
            aimAngle = GetJoypadAngle();
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

    public float GetJoypadAngle()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        //If there is no input on the joystick then remain facing in the current direction.
        if(input == Vector3.zero)
        {
            return Mathf.Atan2(input.y, input.x) * 180f / Mathf.PI;
        }
        else
        {
            return aimAngle;
        }
    }
}
