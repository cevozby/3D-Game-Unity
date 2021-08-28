using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arac_kontrolu : MonoBehaviour
{
    public static float aracHizi=500f, donus=50f, nitroTime=0f;
    public WheelCollider OnSolCollider, OnSagCollider, ArkaSolCollider, ArkaSagCollider;
    public Transform TekerOnSol, TekerOnSag, TekerArkaSol, TekerArkaSag;
    public Quaternion yeniAci;
    public GameObject coin, finishLine;
    public float speed=0f;
    float i, j = 0f;
    float FrenGucu=1000f;

    void Start()
    {
        /*int level = Random.Range(0, 2);
        switch (level)
        {
            case 0:
                finishLine.SetActive(true);
                ArrowMovement.finishLine = true;
                
                break;
            case 1:
                coin.SetActive(true);
                ArrowMovement.coin = true;
                break;
        }
        Debug.Log(level);*/
    }


    void Update()
    {
        if (nitroTime <= 0f)
        {
            aracHizi = 500f;
            donus = 30f;
            FrenGucu = 1000f;
        }
        if (nitroTime > 0f)
        {
            aracHizi = 1000f;
            donus = 60f;
            FrenGucu = 1500f;
            nitroTime -= Time.deltaTime;
            Debug.Log(nitroTime);
        }
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            for (i = j; i <= aracHizi; i += 0.001f)
            {
                ArkaSagCollider.motorTorque = Input.GetAxis("Vertical") * i;
                ArkaSolCollider.motorTorque = Input.GetAxis("Vertical") * i;
                j = i;
            }
        }
        else 
        {
            /*for(i = j; i>=0; i -= 0.5f)
            {

            }*/
            j -= 0.5f;
            ArkaSagCollider.motorTorque = Input.GetAxis("Vertical") * j;
            ArkaSolCollider.motorTorque = Input.GetAxis("Vertical") * j;
        }
        
        
        
        
        speed = ArkaSagCollider.motorTorque;

        OnSolCollider.steerAngle = Input.GetAxis("Horizontal") * donus;
        OnSagCollider.steerAngle = Input.GetAxis("Horizontal") * donus;

        

        if (Input.GetKey(KeyCode.Space))
        {
            ArkaSagCollider.brakeTorque = FrenGucu;
            ArkaSolCollider.brakeTorque = FrenGucu;

        }
        else
        {
            TekerHareketi();
            ArkaSagCollider.brakeTorque = 0;
            ArkaSolCollider.brakeTorque = 0;
        }

        
    }
    
    void TekerHareketi()
    {
        Vector3 pozisyon;
        Quaternion aci;
        

        OnSolCollider.GetWorldPose(out pozisyon, out aci);
        TekerOnSol.position = pozisyon;
        TekerOnSol.rotation = aci;

        OnSagCollider.GetWorldPose(out pozisyon, out aci);
        TekerOnSag.position = pozisyon;
        TekerOnSag.rotation = aci;

        ArkaSolCollider.GetWorldPose(out pozisyon, out aci);
        TekerArkaSol.position = pozisyon;
        TekerArkaSol.rotation = aci;

        ArkaSagCollider.GetWorldPose(out pozisyon, out aci);
        TekerArkaSag.position = pozisyon;
        TekerArkaSag.rotation = aci;
    }
}
