using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToGrass : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider) {
    	if(collider.tag.Equals("Player")){
    		SceneManager.LoadSceneAsync("Grasslands", LoadSceneMode.Single);
    	}
    }
}
