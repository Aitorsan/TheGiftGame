using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GuiManager : MonoBehaviour
{
   
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
