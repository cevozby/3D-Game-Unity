using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public Transform coinTarget, finishLineTarget, konum;
    public Vector3 mesafe, targetLocation;
    public float positionSofty, rotationSofty;
    Rigidbody arrow;
    public static bool coin=false, finishLine=false;
    void Start()
    {
        arrow = GetComponent<Rigidbody>();
    }

    void Update()
    {
        this.arrow.velocity.Normalize();
        if (coin)
        {
            targetLocation = new Vector3(coinTarget.position.x, 1f, coinTarget.position.z);
        }
        else if (finishLine)
        {
            targetLocation = new Vector3(finishLineTarget.position.x, 1f, finishLineTarget.position.z);
        }
        transform.LookAt(targetLocation);
        Quaternion arrowRotation = transform.rotation;
        Vector3 arrowLocation = konum.position + konum.TransformDirection(mesafe);

        if(arrowLocation.y < konum.position.y)
        {
            arrowLocation.y = konum.position.y;
        }
        transform.position = Vector3.Lerp(transform.position, arrowLocation, Time.deltaTime * positionSofty);
        transform.rotation = Quaternion.Lerp(transform.rotation, arrowRotation, Time.deltaTime * rotationSofty);
        if (transform.position.y < 0.5f)
        {
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }
    }
}
