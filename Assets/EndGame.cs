using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    public AudioSource EndGameSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        EndGameSound.Play();
        for (int i = 0; i < 100000; ++i) ;

         SceneManager.LoadScene("EndGameScene");
    }

}
