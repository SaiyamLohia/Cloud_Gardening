using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    static Audio[] instance;

    void Start()
    {
        instance = FindObjectsOfType<Audio>();
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance.Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
