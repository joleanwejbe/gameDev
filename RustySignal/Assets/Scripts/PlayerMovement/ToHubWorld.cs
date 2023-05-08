using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ToHubWorld : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == ("Player"))
        {
            SceneManager.LoadSceneAsync("HubWorld", LoadSceneMode.Single);
        }
    }
}
