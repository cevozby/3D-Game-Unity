using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareket : MonoBehaviour
{
    public float hareketHizi;

    void Start()
    {
        
    }


    void Update()
    {
        float yataykontrol = Input.GetAxis("Horizontal") * hareketHizi;
        if (Input.GetKey(KeyCode.W) )
        {
            transform.Rotate(0f, yataykontrol, 0f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(0f, -yataykontrol, 0f);
        }
    }
}
