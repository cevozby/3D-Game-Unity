using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Coin : MonoBehaviour
{
    int coinValue, finishCoin=3;
    public Transform carLocation;
    public float speed = 5f, height = 0.5f, rotationSpeed;
    float time = 25f;
    Vector3 pos;
    public TextMeshProUGUI coinValues, timeText, gameOverText;
    public GameObject gameOverPanel, coinPanel, timePanel;
    void Start()
    {
        CoinLocation();
        coinPanel.SetActive(true);
        timePanel.SetActive(true);
    }


    void FixedUpdate()
    {
        float xPozisyon = Mathf.Clamp(transform.position.x, -160f, 160f);
        float zPozisyon = Mathf.Clamp(transform.position.z, -165f, 165f);
        transform.position = new Vector3(xPozisyon, transform.position.y, zPozisyon);
        /*Vector3 coinUpMovement = new Vector3 (transform.position.x, 1.3f, transform.position.z);
        Vector3 coinDownMovement = new Vector3(transform.position.x, 0.5f, transform.position.z);*/
        

        float newY = Mathf.Sin(Time.time * speed);

        transform.position = new Vector3(pos.x, newY * height + height + 2f, pos.z);

        transform.eulerAngles = new Vector3(90f, 0f, rotationSpeed);
        rotationSpeed++;
        if (rotationSpeed == 360f)
        {
            rotationSpeed = 0f;
        }
        
        
    }
    private void Update()
    {
        coinValues.text = "Coin: " + coinValue.ToString() + "/" + finishCoin.ToString();
        Countdown();
        if (Time.timeScale == 0)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            }
        }
        Win();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            coinValue++;
            time += 10f;
            CoinLocation();
        }
        if (other.gameObject.tag == "BuildingStructure")
        {
            CoinLocation();
        }
    }
    void Countdown()
    {
        timeText.text = time.ToString("0") + "s";
        time -= Time.deltaTime;
        if (time <= 0f)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            gameOverText.text = "Game Over\nPress enter to start again\nCoin value: " + coinValue.ToString() + "/" + finishCoin.ToString();

        }
        
    }
    void CoinLocation()
    {
        int konum = Random.Range(0, 4);
        switch (konum)
        {
            case 0:
                transform.position = new Vector3(carLocation.position.x + Random.Range(-50f, -40f), 2f, carLocation.position.z + Random.Range(50f, 40f));
                break;
            case 1:
                transform.position = new Vector3(carLocation.position.x + Random.Range(-50f, -40f), 2f, carLocation.position.z + Random.Range(-50f, -40f));
                break;
            case 2:
                transform.position = new Vector3(carLocation.position.x + Random.Range(50f, 40f), 2f, carLocation.position.z + Random.Range(50f, 40f));
                break;
            case 3:
                transform.position = new Vector3(carLocation.position.x + Random.Range(50f, 40f), 2f, carLocation.position.z + Random.Range(-50f, -40f));
                break;
        }
        pos = transform.position;
    }
    void Win()
    {
        if (coinValue == finishCoin)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            gameOverText.text = "You win\nPress enter to start next level\nCoin value: " + coinValue.ToString() + "/" + finishCoin.ToString();
            finishCoin++;
        }
    }
 
}
