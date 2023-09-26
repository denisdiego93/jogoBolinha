using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float sdeath = -7;

    public Transform playerReference;

    void Update()
    {
        if (playerReference.position.y < sdeath) {
            SceneManager.LoadScene("Fase");
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Final");
    }
}
