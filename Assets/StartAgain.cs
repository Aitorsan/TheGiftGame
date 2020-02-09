using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAgain : MonoBehaviour
{
   void Update()
    {
        if (Input.touchCount > 4)
            SceneManager.LoadScene("UiScene");
    }
    
}

