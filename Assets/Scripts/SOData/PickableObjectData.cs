using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu]
public class PickableObjectData : ScriptableObject
{
    [SerializeField]
    private int _holyFlameCount;
    [SerializeField]
    private int _favoursCount;


	public int holyFlameCount
	{
		get { return _holyFlameCount; }
		set { _holyFlameCount = value; }
	}

    public int favoursCount
    {
        get { return _favoursCount; }
        set { _favoursCount = value; }
    }
}
