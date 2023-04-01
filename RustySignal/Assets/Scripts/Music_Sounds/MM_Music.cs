using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MM_Music : MonoBehaviour
{
    void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("MM_Music");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
