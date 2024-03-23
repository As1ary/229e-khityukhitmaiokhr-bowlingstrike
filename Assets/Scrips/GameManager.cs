using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject bowlingPrefab;
    [SerializeField] private GameObject bowlingPositions;
    [SerializeField] private GameObject pinsPrefab;
    [SerializeField] private GameObject[] pinsPositions;
    [SerializeField] private TMP_Text textMeshProText;
    [SerializeField] private Text scoreUI;
    [SerializeField] private Text respawnCountUI;
    [SerializeField] private Button respawnButton;
    [SerializeField] private int maxRespawnCount = 1; // Maximum number of respawns allowed
    [SerializeField] private TextMeshProUGUI scoreText;
    private GameObject currentBowlingBall;
    private int score = 0;
    private int respawnCount = 0; // Number of times respawned
    private GameObject[] pins;
    private bool ballRespawning = false;
    private int remainingPins;
    public static GameManager instance;
    
    

    void Start()
    {
        instance = this;
        SetPins();
        SetBowling();
        pins = GameObject.FindGameObjectsWithTag("Pins");
        respawnButton.onClick.AddListener(RespawnBowlingBall);
        UpdateRespawnCountUI();
        textMeshProText.text = "Respawn";

    }

    private void ChangeSceneButtonClicked()
    {
        throw new NotImplementedException();
    }

    void Update()
    {
        CountPinsDown();
        if (respawnCount ==0)
        {
            textMeshProText.text = "Next";
        }
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
        
    }

    private void SetPins()
    {
        remainingPins = pinsPositions.Length;
        for (int i = 0; i < pinsPositions.Length; i++)
        {
            Instantiate(pinsPrefab, pinsPositions[i].transform.position, Quaternion.identity);
        }
    }
    

    private void SetBowling()
    {
        currentBowlingBall = Instantiate(bowlingPrefab, bowlingPositions.transform.position, Quaternion.identity);
    }

    private void CountPinsDown()
    {
        for(int i = 0; i < pins.Length; i++)
        {
            if(pins[i].transform.eulerAngles.z > 5 && pins[i].transform.eulerAngles.z < 355 && pins[i].activeSelf)
            {
                score++;
                pins[i].SetActive(false);
            }
            scoreUI.text = score.ToString();
            
        }
        
        if (score > 0 && !ballRespawning)
        {
            ballRespawning = true;
            respawnButton.gameObject.SetActive(true);
        }
        if (remainingPins == 0)
        {

            SceneManager.LoadScene("SummarizeScene");
        }
        
    }

    private void UpdateRespawnButton()
    {
        respawnButton.gameObject.SetActive(respawnCount > 0);
    }

    private void RespawnBowlingBall()
    {
        if (respawnCount < maxRespawnCount)
        {
            respawnCount++;
            UpdateRespawnCountUI();
            UpdateRespawnButton();

            if (currentBowlingBall != null)
            {
                Destroy(currentBowlingBall);
            }
    
            SetBowling();
            ballRespawning = false;
            score = 0;
            scoreUI.text = score.ToString();
            foreach (GameObject pin in pins)
            {
                pin.SetActive(true);
            }
        }
        else
        {
            // Change scene after the final respawn
            SceneManager.LoadScene("SummarizeScene");
        }
}

    private void UpdateRespawnCountUI()
    {
        respawnCountUI.text = "Respawn Left: " + (maxRespawnCount - respawnCount);
    }
    void UpdateScoreUI()
    {
        scoreText.text = "Your Score: " + score.ToString(); 
    }
    
}




    

