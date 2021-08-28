using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public Transform carLocation;
    float speed = 5f, height = 0.5f, time = 30f;
    Vector3 position;
    public GameObject finishPanel, timePanel;
    public TextMeshProUGUI finishText, timeText;


    void Start()
    {
        FinishLineLocation();
        timePanel.SetActive(true);
    }

    void Update()
    {
        float xPozisyon = Mathf.Clamp(transform.position.x, -338f, 338f);
        float zPozisyon = Mathf.Clamp(transform.position.z, -341f, 341f);
        transform.position = new Vector3(xPozisyon, transform.position.y, zPozisyon);

        float newY = Mathf.Sin(Time.time * speed);

        transform.position = new Vector3(position.x, newY * height + height + 2f, position.z);

        Countdown();
        if (Time.timeScale == 0)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            Time.timeScale = 0;
            finishPanel.SetActive(true);
            finishText.text = "You Win\nPress enter to next level";

        }
        if (other.gameObject.tag == "BuildingStructure")
        {
            FinishLineLocation();
        }
    }
    void FinishLineLocation()
    {
        int konum = Random.Range(0, 4);
        switch (konum)
        {
            case 0:
                transform.position = new Vector3(90.5f, 2f, 120f);
                break;
            case 1:
                transform.position = new Vector3(90.5f, 2f, -122f);
                break;
            case 2:
                transform.position = new Vector3(-87f, 2f, 120f);
                break;
            case 3:
                transform.position = new Vector3(-87f, 2f, -122f);
                break;
        }
        position = transform.position;
    }
    void Countdown()
    {
        timeText.text = time.ToString("0") + "s";
        time -= Time.deltaTime;
        if (time <= 0f)
        {
            Time.timeScale = 0;
            finishPanel.SetActive(true);
            finishText.text = "Game Over\nPress enter to start again";

        }
    }
}
