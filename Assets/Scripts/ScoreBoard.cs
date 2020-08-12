using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{

    int currScore;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = currScore.ToString();
    }

    public void ScoreHit(int scoreGained)
    {
        currScore += scoreGained;
        scoreText.text = currScore.ToString();
    }
}
