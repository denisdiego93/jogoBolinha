using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenFloor : MonoBehaviour
{
    public int life = 3;

    void Update()
    {       
        if(life == 0) { 
            Destroy(this.gameObject);
        }
    }

    public void PerdeVida()
    {
        life--;
    }


}
