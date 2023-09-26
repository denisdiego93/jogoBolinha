using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using System.Diagnostics;

public class Movement : MonoBehaviour
{
    public float speed = 10.0f;

    public GameObject particulaItem;

    public TextMeshProUGUI textoPontosCapsula;
    public TextMeshProUGUI textoPontosCubos;
    
    private int pontosCapsula;
    private int pontosCubos;    

    Rigidbody rb;
    void Start()
    {
        pontosCapsula = 0;
        pontosCubos = 0;
        setPointsCapsulaText();
        setPointsCuboText();
        chamaVitoria();

        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveVertical, 0, moveHorizontal);
        rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherObject = collision.gameObject;

        if (otherObject.CompareTag("cx-colect")) 
        {
            if (otherObject.GetComponent<MeshRenderer>().material.color != Color.yellow)
            {
                otherObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
                pontosCubos++;
                setPointsCuboText();
                chamaVitoria();
            }
            
        }

        if (otherObject.GetComponent<BrokenFloor>() != null)
        {
            BrokenFloor brokenFloor;
            brokenFloor = otherObject.GetComponent<BrokenFloor>();
            
            brokenFloor.PerdeVida();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("colectavel"))
        {
            pontosCapsula ++;
            setPointsCapsulaText();
            chamaVitoria();
            other.gameObject.SetActive(false);
        }
    }

    void setPointsCapsulaText()
    {
        textoPontosCapsula.text = "Capsula: " + pontosCapsula + "/1";
    }

    void setPointsCuboText()
    {
        textoPontosCubos.text = "Cubos: " + pontosCubos + "/6";
    }

    void chamaVitoria()
    {
        if(pontosCapsula == 1 && pontosCubos == 6)
        {
            GameObject.FindAnyObjectByType<GameManager>().EndGame();            
        }
    }
}
