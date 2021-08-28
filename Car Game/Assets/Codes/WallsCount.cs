using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsCount : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Police")
        {
            PoliceSide.vehicleCount--;
            Debug.Log(PoliceSide.vehicleCount);
        }
    }

}
