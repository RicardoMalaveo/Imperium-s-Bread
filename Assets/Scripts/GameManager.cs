using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Vector3 lastCheckPoint;
    public int favourPoints = 0;
    public int holyFlameCount = 0;
    public int holyFlareMaxCount = 5;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        transform.position = lastCheckPoint;
    }

}
