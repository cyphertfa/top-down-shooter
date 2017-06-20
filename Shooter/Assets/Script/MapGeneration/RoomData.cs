using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

/// <summary>
/// Represents a list of all rooms available to the world generator at runtime.
/// </summary>
public class RoomLibrary
{
    private List<RoomData> rooms;


}

public class RoomData
{
    public NavMeshData NavMeshData;
    public GameObject Prefab;

    public List<string> Tags;

}


