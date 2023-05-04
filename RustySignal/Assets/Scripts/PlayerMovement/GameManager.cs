using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private Vector3 respawnPosition;
    //private Vector3 camSpawnPosition;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //when the game is being played the mouse will not be visible
        Cursor.visible = false;
        //When the game is played the cursor will not appear even if clicked outside window(esc key is required)
        Cursor.lockState = CursorLockMode.Locked;

        respawnPosition = WPlayerController.instance.transform.position;

        //camSpawnPosition = CameraController.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Resawn is called when played is being respawned
    public void Respawn()
    {
        Debug.Log("I'm Respawning");
        StartCoroutine(RespawnCo());
    }

    public IEnumerator RespawnCo()
    {
        //when player is dead the player is now gone
        WPlayerController.instance.gameObject.SetActive(false);

        //Disabling cinemachine so that the camera does not snap back with the characer
        CameraController.instance.theCMBrain.enabled = false;

        //delays respawning for x seconds
        yield return new WaitForSeconds(2f);

        //When player is dead reset spawn point
        WPlayerController.instance.transform.position = respawnPosition;

        //re enable the cinemachine brain
        CameraController.instance.theCMBrain.enabled = true;

        //After spawn point is reset bring the character game object back
        WPlayerController.instance.gameObject.SetActive(true);
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        respawnPosition = newSpawnPoint;
        Debug.Log("New Spawn Point Set");
    }
}
