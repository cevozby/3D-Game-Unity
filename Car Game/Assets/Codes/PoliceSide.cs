using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSide : MonoBehaviour
{
    public GameObject FB, RL;
    bool FBPolice = false, RLPolice = false;
    public static int vehicleCount = 14;
    int side;

    void Start()
    {
        PolicePatrol();
        Debug.Log("Start");
    }


    private void FixedUpdate()
    {
        
    }
    void Update()
    {
        if (vehicleCount <= 0)
        {
            PolicePatrol();
            vehicleCount = 14;
        }
    }

    
    void PolicePatrol()
    {
        /*if (FBPolice == true)
        {
            FB.SetActive(false);
        }
        else if (RLPolice == true)
        {
            RL.SetActive(false);
        }*/

        side = Random.Range(0, 2);
        switch (side)
        {
            case 0:
                FB.SetActive(true);
                RL.SetActive(false);
                /*FBPolice = true;
                RLPolice = false;*/

                break;
            case 1:
                RL.SetActive(true);
                FB.SetActive(false);
                /*RLPolice = true;
                FBPolice = false;*/
                break;
        }
        Debug.Log("side = "+ side);
        vehicleCount = 14;
    }
}
