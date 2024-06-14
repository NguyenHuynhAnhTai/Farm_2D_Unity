using System.Collections;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    private static RespawnManager _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static RespawnManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<RespawnManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("RespawnManager");
                    _instance = obj.AddComponent<RespawnManager>();
                }
            }
            return _instance;
        }
    }

    public void StartRespawnCoroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
}
