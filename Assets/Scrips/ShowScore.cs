using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        // Retrieve the score from PlayerPrefs
        int score = PlayerPrefs.GetInt("Score", 0);

        // Display the score in TextMeshProUGUI
        scoreText.text = "Your Score: " + score.ToString();
    }


}
