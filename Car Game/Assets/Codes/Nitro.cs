using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : MonoBehaviour
{
    
    public float speed = 5f, height = 0.5f, rotationSpeed;
    public GameObject nitroPrefab;
    Vector3 pos;

    void Start()
    {
        int i;
        transform.position = new Vector3(Random.Range(-160f, 160f), 2f, Random.Range(-165f, 165f));
        for (i=0; i <= 20; i++)
        {
            if (i <= 5)
            {
                Instantiate(nitroPrefab, new Vector3(Random.Range(-160f, 0f), 2f, Random.Range(-165f, 0f)), Quaternion.identity);
            }
            else if (i <= 10)
            {
                Instantiate(nitroPrefab, new Vector3(Random.Range(-160f, 0f), 2f, Random.Range(0f, 165f)), Quaternion.identity);
            }
            else if (i <= 15)
            {
                Instantiate(nitroPrefab, new Vector3(Random.Range(0f, 160f), 2f, Random.Range(-165f, 0f)), Quaternion.identity);
            }
            else if (i <= 20)
            {
                Instantiate(nitroPrefab, new Vector3(Random.Range(0f, 160f), 2f, Random.Range(0f, 165f)), Quaternion.identity);
            }
            Instantiate(nitroPrefab, new Vector3(Random.Range(-160f, 160f), 2f, Random.Range(-165f, 165f)), Quaternion.identity);
            
        }
        //transform.position = new Vector3(-4f, 2f, 4f);
    }
    private void FixedUpdate()
    {
        float xPozisyon = Mathf.Clamp(transform.position.x, -160f, 160f);
        float zPozisyon = Mathf.Clamp(transform.position.z, -165f, 165f);
        transform.position = new Vector3(xPozisyon, transform.position.y, zPozisyon);

        float newY = Mathf.Sin(Time.time * speed);

        transform.position = new Vector3(transform.position.x, newY * height + height + 1.5f, transform.position.z);

        transform.eulerAngles = new Vector3(90f, 0f, rotationSpeed);
        rotationSpeed++;
        if (rotationSpeed == 360f)
        {
            rotationSpeed = 0f;
        }
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "BuildingStructure")
        {
            transform.position = new Vector3(Random.Range(-160f, 160f), 2f, Random.Range(-165f, 165f));
        }
        if (other.gameObject.tag == "Car")
        {
            arac_kontrolu.nitroTime = 5f;
            Destroy(gameObject);
        }
    }
    /*
    {
        
    }*/
}
