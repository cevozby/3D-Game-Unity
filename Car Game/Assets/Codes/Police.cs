using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Police : MonoBehaviour
{
    float policeVehicleSpeed = 400f, startTime;
    public WheelCollider LeftFront, RightFront, LeftRear, RightRear;
    public Transform LeftFrontWheel, RightFrontWheel, LeftRearWheel, RightRearWheel;
    public Quaternion newangle, startAngle;
    Vector3 startPosition;
    public Rigidbody rb;
    public TextMeshProUGUI gameOverText;
    public GameObject gameOverPanel;

    void Start()
    {
        startPosition = transform.position;
        startAngle = transform.rotation;
        startTime = Random.Range(1f, 5.1f);
        rb = GetComponent<Rigidbody>();
        
    }

    private void FixedUpdate()
    {
        
        if (startTime > 0f)
        {
            RightRear.motorTorque = 0f;
            LeftRear.motorTorque = 0f;
            rb.velocity = new Vector3(0, 0, 0);
            transform.rotation = startAngle;

        }

    }

    void Update()
    {
        
        if (startTime > 0f)
        {
            startTime -= Time.deltaTime;

        }
        
        else if (startTime <= 0f)
        {
            
            RightRear.motorTorque = policeVehicleSpeed;
            LeftRear.motorTorque = policeVehicleSpeed;

            WheelMovement();
        }
        if (Time.timeScale == 0)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Wall" || collision.gameObject.tag== "BuildingStructure" || collision.gameObject.tag == "Police")
        {
            transform.position = startPosition;
            transform.rotation = startAngle;
        }
        if (collision.gameObject.tag == "Car")
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            gameOverText.text = "Game Over\nPress enter to start again";
        }
    }

    void WheelMovement()
    {
        Vector3 position;
        Quaternion angle;


        LeftFront.GetWorldPose(out position, out angle);
        LeftFrontWheel.position = position;
        LeftFrontWheel.rotation = angle;

        RightFront.GetWorldPose(out position, out angle);
        RightFrontWheel.position = position;
        RightFrontWheel.rotation = angle;

        LeftRear.GetWorldPose(out position, out angle);
        LeftRearWheel.position = position;
        LeftRearWheel.rotation = angle;

        RightRear.GetWorldPose(out position, out angle);
        RightRearWheel.position = position;
        RightRearWheel.rotation = angle;
    }

    
}
