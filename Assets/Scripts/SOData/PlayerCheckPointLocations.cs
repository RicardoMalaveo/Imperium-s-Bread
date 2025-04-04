using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu]
public class PlayerCheckPointLocations : ScriptableObject
{
    [SerializeField]
    private Vector3 _respawmPoint;
    [SerializeField]
    private Vector3 _currentCheckPoint;


    public Vector3 respawnPoint
    {
        get { return _respawmPoint; }
        set { _respawmPoint = value; }
    }

    public Vector3 currentCheckPoint
    {
        get { return _currentCheckPoint; }
        set { _currentCheckPoint = value; }
    }
}
