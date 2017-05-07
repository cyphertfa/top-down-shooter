using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObject : MonoBehaviour {
	public int health = 10; 
	// Use this for initialization

	
	// Update is called once per frame
	void Update () 
	{
		// Destroy this game object when health is less than or equal to 0
		if (health <= 0)
		{
			Destroy(gameObject);
			Debug.Log ("pew pew dead ");
		}

	}
	void OnCollisionEnter2D (Collision2D col)
	{		
		//if statement to decrease health by 1 every time a game object with a tag "Bullet" hit  
		if(col.gameObject.tag == "Bullet")
		{
			health -= 1;
			Debug.Log (health+ "hit" );
		}
	}
}
