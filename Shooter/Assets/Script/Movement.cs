using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    /// <summary>
    /// The non-sprinting speed this game object moves at.
    /// </summary>
    public float MoveSpeed = 12;
    /// <summary>
    /// The sprinting speed this game object moves at.
    /// </summary>
    public float RunSpeed = 24;



    //These values will be populated during updates.
    private Vector2 direction;
    private bool isSprinting;

    // Use this for initialization
    void Start()
    {
    }


    public void SetMovement(Vector2 direction, bool isSprinting)
    {
        this.direction = direction;
        this.isSprinting = isSprinting;

    }

    // Update is called once per frame
    void Update()
    {
        //Calculate the velocity based on the direction and move/run speed.
        Vector2 velocity = new Vector2();
        velocity = direction * (isSprinting ? RunSpeed : MoveSpeed);

        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.velocity = velocity;
    }
}
