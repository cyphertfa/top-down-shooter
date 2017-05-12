using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public int maxHealth = 10;
	public int currentHealth = 10; 
	// Use this for initialization

	
	// Update is called once per frame
	void Update () 
	{
		// Destroy this game object when health is less than or equal to 0
		if (currentHealth <= 0)
		{
            //TODO: Need to hook into this for other systems (drops, game over ect.)
			Destroy(gameObject);
			//Debug.Log ("pew pew dead ");
		}

	}
	void OnCollisionEnter2D (Collision2D col)
	{		
		//if statement to decrease health by 1 every time a game object with a tag "Bullet" hit  
		if(col.gameObject.tag == "Bullet")
		{
            Damage(1);
			
		}
	}

    public void Damage(int amount)
    {
        currentHealth = Mathf.Max(currentHealth - amount, 0);
        Debug.Log(string.Format("Took {0} damage. {1} / {2} HP", amount, currentHealth, maxHealth));
    }
}
