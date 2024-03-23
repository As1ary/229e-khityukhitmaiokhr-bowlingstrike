using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        int score = PlayerPrefs.GetInt("Score", 0); // Load the score from PlayerPrefs
        scoreText.text = "Yore Score: " + score.ToString(); // Display the score
    }
}
