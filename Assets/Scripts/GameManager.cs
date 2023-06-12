using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float speedMultiplier;

    public static bool GameIsOver;
    public GameObject gameOverUI;

    public Text distanceUI;

    public Text coinText;
    private int coinCount;

    public Text currDistText;
    public Text highDistText;

    private int randomIndex;
    public GameObject[] backgroundToChange;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        randomIndex = Random.Range(0, backgroundToChange.Length);
        ChangeBackgound();
    }
    private void Start()
    {
        GameIsOver = false;

        distanceUI.text = PlayerStats.Distance.ToString("F0");
        randomIndex = Random.Range(0, backgroundToChange.Length);
        UpdateHighDistanceText();

    }
    void UpdateHighDistanceText()
    {
        highDistText.text = PlayerPrefs.GetFloat("HighDistance").ToString("F0"); ;
    }
    void CheckHighDistance()
    {
        if (PlayerStats.Distance > PlayerPrefs.GetFloat("HighDistance", 0))
        {
            PlayerPrefs.SetFloat("HighDistance", PlayerStats.Distance);
        }
    }

    void Update()
    {
        speedMultiplier += Time.deltaTime * 0.05f;

        if (GameIsOver)
            return;

        distanceUI.text = "DISTANCE: " + PlayerStats.Distance.ToString("F0");
        PlayerStats.Distance += Time.deltaTime;
        currDistText.text = PlayerStats.Distance.ToString("F0");
        CheckHighDistance();
        UpdateHighDistanceText();

    }
    public void AddCoin()
    {
        coinCount++;
        coinText.text = coinCount.ToString();
    }

    public void ChangeBackgound()
    {
        Instantiate(backgroundToChange[randomIndex]);
    }
    public void GameOver()
    { 
       GameIsOver = true;
       gameOverUI.SetActive(true);
    }
}
