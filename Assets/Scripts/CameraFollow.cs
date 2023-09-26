using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objectoFollow;
    public Vector3 offset;

    void Start()
    {
        offset = this.transform.position - objectoFollow.position;
    }

    void Update()
    {
       this.transform.position = objectoFollow.transform.position + offset;
    }
}
