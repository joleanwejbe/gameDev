using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //when the game is being played the mouse will not be visible
        Cursor.visible = false;
        //When the game is played the cursor will not appear even if clicked outside window(esc key is required)
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
