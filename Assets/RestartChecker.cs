using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartChecker : MonoBehaviour
{
    public static RestartChecker Instance;

    public bool isRestart = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
