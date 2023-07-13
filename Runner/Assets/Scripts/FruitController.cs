using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FruitController : MonoBehaviour
{
    public static FruitController instance;
    float rotationSpeed = 100;

    void Awake() { instance = this; }

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed += Random.Range(0, rotationSpeed / 4.0f);
        ScoreManager.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.parent.gameObject.SetActive(false);

            if (this.gameObject.tag == "Score1")
            {
                ScoreManager.score += 1;
            }
            
            if (this.gameObject.tag == "Score2")
            {
                ScoreManager.score += 2;

            }

            if (this.gameObject.tag == "Score3")
            {
                ScoreManager.score += 3;
            }
        }
    }

    public void ResetLevel()
    {
        ScoreManager.score = 0;
    }

    
}
