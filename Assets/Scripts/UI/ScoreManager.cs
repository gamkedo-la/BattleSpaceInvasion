using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private Text display;
    private int score = 0;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        display = gameObject.GetComponent<Text>();
        UpdateScore(); //Singleton
    }

    public void AddPoints(int newPoints)
    {
        score += newPoints;
        UpdateScore();
    }

    void UpdateScore()
    {
        display.text = "0000" + score;
    }
        
}
