using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationController : MonoBehaviour {

    LineRenderer lineRenderer;

    public BakeNavMeshes NavMeshManager;
    public Transform Destination;

    // Use this for initialization
    void Start () {
        lineRenderer = GetComponent<LineRenderer>();
    }
	

	// Update is called once per frame
	void Update () {
        //Rotate the world into the XZ coordinate system.
        NavMeshManager.SetNavigationMode(true);

        //Perform pathfinding.
        NavMeshPath path = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, Destination.position,NavMesh.AllAreas, path);

        if(path.corners.Length >1)
        {
            //Find the vector between this GameObject and the next waypoint.
            Vector3 nextVelocity;
            Vector3 posA = transform.position;
            Vector3 posB = path.corners[1];
            nextVelocity = (posB - posA);
            nextVelocity.Normalize();
            //Velocity needs to be converted to XY from XZ.
            nextVelocity = new Vector3(nextVelocity.x, nextVelocity.z, nextVelocity.y);

            GetComponent<Rigidbody2D>().velocity = nextVelocity;
        }
        //Rotate the world back to XY.
        NavMeshManager.SetNavigationMode(false);

        DrawPath(path);
    }

    void DrawPath(NavMeshPath path)
    {
        lineRenderer.positionCount = path.corners.Length;

        for (int i = 0; i < path.corners.Length; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(path.corners[i].x, path.corners[i].z, path.corners[i].y));
        }

    }
}
