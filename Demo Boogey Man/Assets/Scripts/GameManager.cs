using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (player.suspicion >= 100f)
        {
            Debug.Log("Perdiste lince");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (player.kidnappedKids == 4)
        {
            Debug.Log("Ganaste pro");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
