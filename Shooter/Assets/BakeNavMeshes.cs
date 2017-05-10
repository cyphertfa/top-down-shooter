using System.Collections;
using System.Collections.Generic;
using UnityEditor.AI;
using UnityEngine;

public class BakeNavMeshes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BakeNavMesh()
    {
        SetNavigationMode(true);
        NavMeshBuilder.BuildNavMesh();
        SetNavigationMode(false);
    }

    public void SetNavigationMode(bool navMode)
    {
        if(navMode)
            transform.localEulerAngles = new Vector3(90, 0, 0);
        else
            transform.localEulerAngles = new Vector3(0, 0, 0);
    }
}
