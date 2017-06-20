using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviour {

    /// <summary>
    /// The GameObject holding all of the offlink meshes (doors).
    /// </summary>
    public GameObject Doors;

    /// <summary>
    /// A way to identify the room for debugging purposes.
    /// </summary>
    public string RoomName;

    public NavMeshData Nav;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AttachRoom()
    {
        NavMesh.AddNavMeshData(Nav, new Vector3(), new Quaternion());
    }
}
