using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public Button startButton;
    Vector3 startButtonPos;

    public static int score;
    void Awake() { instance = this; }
    // Start is called before the first frame update
    void Start()
    {
        startButtonPos = startButton.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void ResetLevel()
    {
        startButton.interactable = true;
        startButton.transform.position = startButtonPos;
    }

    public void StartLevel()
    {
        startButton.interactable = false;
        startButton.transform.position = Vector3.zero;
    }
}
