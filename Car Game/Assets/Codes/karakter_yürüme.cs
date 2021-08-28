using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakter_yürüme : MonoBehaviour
{
    public Animator animasyon;
    void Start()
    {
        
    }


    void Update()
    {
        animasyon.SetFloat("Hiz", Input.GetAxis("Vertical"));
        animasyon.SetBool("Kosu", Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift));

        //animasyon.SetFloat("Hiz", Input.GetAxis("Horizontal"));
    }
}
