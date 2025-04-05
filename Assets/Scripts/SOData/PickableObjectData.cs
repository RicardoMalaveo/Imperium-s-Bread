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
    [SerializeField]
    private int _holyFlamePrice = 15;


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
    public int holyFlamePrice
    {
        get { return _holyFlamePrice; }
        set { _holyFlamePrice = value; }
    }
}
