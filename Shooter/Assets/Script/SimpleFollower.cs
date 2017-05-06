using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollower : MonoBehaviour {

    /// <summary>
    /// Target Transform for the camera to follow.
    /// </summary>
    public Transform Target;
    /// <summary>
    /// Weight between the player and the player + cursor offset.
    /// </summary>
    public float Weight = 0f;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        float posWeight = 1 - Weight;

        float z = transform.position.z;
        Vector3 mousePosition = Input.mousePosition;

        Vector3 posTarget = new Vector3(Target.position.x, Target.position.y, z);
        Vector3 posMouse = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, z)) - Camera.main.transform.position;
        //Reset the Z value
        posMouse.Set(posMouse.x,posMouse.y, z);

        Vector3 finalPosition = posTarget - posMouse*Weight;
        transform.position = new Vector3(finalPosition.x, finalPosition.y, z);
    }
}
