using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Animator animator;
    Vector3 startGamePosition;
    Quaternion startGameRotation;
    Vector3 targetPos;
    float laneOffset = 2.9f;
    float laneChangeSpeed = 10;

    private void Start()
    {
        animator = GetComponent<Animator>();
        startGamePosition = transform.position;
        startGameRotation = transform.rotation; 
        targetPos = transform.position;
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            targetPos = new Vector3(targetPos.x - laneOffset, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            targetPos = new Vector3(targetPos.x + laneOffset, transform.position.y, transform.position.z);
        }
    }
        
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, laneChangeSpeed * Time.deltaTime);
    }

    public void StartGame()
    {
        animator.SetTrigger("ToStartFly");
    }

    public void StartLevel()
    {
        RoadGenerator.instance.StartLevel();
        ItemGenerator.instance.StartLevel();
        ScoreManager.instance.StartLevel();
    }

    public void ResetGame()
    {
        animator.SetTrigger("ToFlyWait");
        transform.position = startGamePosition;
        transform.rotation = startGameRotation;
        RoadGenerator.instance.ResetLevel();
        ItemGenerator.instance.ResetLevel();
        FruitController.instance.ResetLevel();
        ScoreManager.instance.ResetLevel();
        Start();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GameOver")
        {
            ResetGame();
        }
    }
}    