using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Doors are connections between rooms.
/// Provides information to the world generation.
/// </summary>
public class Door : MonoBehaviour {

    public enum DoorDirection
    {
        UP,
        RIGHT,
        DOWN,
        LEFT
    }

    /// <summary>
    /// The Direction this doorway leads.
    /// This is used so that the world generator knows how to tile rooms.
    /// </summary>
    public DoorDirection Direction;

    /// <summary>
    /// A list of game objects that exist when this door is not used.
    /// If this door leads somewhere the objects in this list will be deleted.
    /// </summary>
    public List<GameObject> InactiveDoorObjects = new List<GameObject>();

    /// <summary>
    /// Indicates if this doorway connects to another room.
    /// </summary>
    public bool Active;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
