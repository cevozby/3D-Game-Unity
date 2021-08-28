using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{
    public Transform arabaHedef;
    public Vector3 ayarlar, tersAyarlar;

    public float postion_yumusakligi, rotation_yumusakligi;
    Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }



    void FixedUpdate()
    {
        this._rb.velocity.Normalize();
        transform.LookAt(arabaHedef);

        if (Input.GetKey(KeyCode.B))
        {
            Quaternion k_rot = transform.rotation;
            Vector3 t_pos = arabaHedef.position + arabaHedef.TransformDirection(tersAyarlar);

            if (t_pos.y < arabaHedef.position.y)
            {
                t_pos.y = arabaHedef.position.y;
            }

            transform.position = Vector3.Lerp(transform.position, t_pos, Time.deltaTime * postion_yumusakligi);
            transform.rotation = Quaternion.Lerp(k_rot, transform.rotation, Time.deltaTime * rotation_yumusakligi);

            if (transform.position.y < 0.5f)
            {
                transform.position = new Vector3(transform.position.x, -0.5f, transform.position.z);
            }
        }
        else
        {
            Quaternion k_rot = transform.rotation;
            Vector3 t_pos = arabaHedef.position + arabaHedef.TransformDirection(ayarlar);

            if (t_pos.y < arabaHedef.position.y)
            {
                t_pos.y = arabaHedef.position.y;
            }

            transform.position = Vector3.Lerp(transform.position, t_pos, Time.deltaTime * postion_yumusakligi);
            transform.rotation = Quaternion.Lerp(k_rot, transform.rotation, Time.deltaTime * rotation_yumusakligi);

            if (transform.position.y < 0.5f)
            {
                transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
            }
        }
        
    }
}
