using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey)
        //if (Input.GetKeyDown(KeyCode.KeypadEquals))
        {
            SceneManager.LoadScene("Fase");
        }
    }
}
