using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Copyright © 2020, Frank Martin
public class ScoreManager : MonoBehaviour
{
    public static int score = 0;

    private Text scoreText; 
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    /*private void OnGUI()
    {
        GUILayout.Label("Hits: " + score);
    }

    */
}
