using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Determines the angle this game object is aiming at.
/// At 0 degrees, Y faces upwards, X faces rightward.
/// </summary>
public class Aim : MonoBehaviour {

    /// <summary>
    /// Maximum speed in degrees per second this object may turn.
    /// </summary>
    public float TurnSpeed = 500;

    /// <summary>
    /// Get the angle this GameObject is aiming towards.
    /// At 0 degrees, Y faces upwards, X faces rightward.
    /// </summary>
    public float AimDegrees {
        get
        {
            return aimAngle;
        }
        set
        {
            aimAngle = value;
        }
    }

    public Vector2 AimVector
    {
        get
        {
            return new Vector2(Mathf.Cos(AimDegrees*Mathf.Deg2Rad), Mathf.Sin(AimDegrees*Mathf.Deg2Rad)); 
        }
        set
        {
            aimAngle = Mathf.Atan2(value.y, value.x) * 180f / Mathf.PI;
        }
    }

   

    private float aimAngle;

	// Use this for initialization
	void Start () {
        aimAngle = 0;
	}
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles = Vector3.forward * Mathf.MoveTowardsAngle(transform.eulerAngles.z, AimDegrees, TurnSpeed * Time.deltaTime);
    }

}
