using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemGenerator : MonoBehaviour
{
    public static ItemGenerator instance;
    public GameObject Barrier1Prefab;
    public GameObject Barrier2Prefab;
    public GameObject Barrier3Prefab;
    public GameObject Fruit1Prefab;
    public GameObject Fruit2Prefab;
    public GameObject Fruit3Prefab;
    private List<GameObject> barriers = new List<GameObject>();
    private List<GameObject> fruits = new List<GameObject>();
    public System.Random rand = new System.Random();
    public float maxSpeed = 10;
    private float speed = 0;
    public int maxItemCount = 5;


    // Start is called before the first frame update
    void Start()
    {
        ResetLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (speed == 0) return;


        for (int j = 0; j < barriers.Count; j++)
        {
            barriers[j].transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
            fruits[j].transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        }


        if (barriers[0].transform.position.z < -30)
        {
            Destroy(barriers[0]);
            barriers.RemoveAt(0);
            Destroy(fruits[0]);
            fruits.RemoveAt(0);
            CreateNextItem();
        }
    }

    private void CreateNextItem()
    {
        List<GameObject> barrierList = new List<GameObject>() { Barrier1Prefab, Barrier2Prefab, Barrier3Prefab };
        List<GameObject> fruitList = new List<GameObject>() { Fruit1Prefab, Fruit2Prefab, Fruit3Prefab };
        List<int> position = new List<int>() { -1, 0, 1 };

        int randForBarrier = position[rand.Next(0, 3)];
        position.Remove(randForBarrier);
        int randForFruit = position[rand.Next(0, 2)];
        
        Vector3 barrierPos = new Vector3(randForBarrier * 3.1f, 0, 0);
        if (barriers.Count > 0) { barrierPos.z = barriers[barriers.Count - 1].transform.position.z + 12; }
        GameObject barrierIns = Instantiate(barrierList[rand.Next(0, 3)], barrierPos, Quaternion.identity);
        barrierIns.transform.SetParent(transform);
        barriers.Add(barrierIns);

        Vector3 fruitPos = new Vector3(randForFruit * 3.1f, 0, 0);
        if (fruits.Count > 0) { fruitPos.z = fruits[fruits.Count - 1].transform.position.z + 12; }
        GameObject fruitIns = Instantiate(fruitList[rand.Next(0, 3)], fruitPos, Quaternion.identity);
        fruitIns.transform.SetParent(transform);
        fruits.Add(fruitIns);
    }

    public void StartLevel()
    {
        speed = maxSpeed;
    }

    public void ResetLevel()
    {
        speed = 0;
        while ((barriers.Count > 0) || (fruits.Count > 0))
        {
            if (barriers.Count > 0)
            {
                Destroy(barriers[0]);
                barriers.RemoveAt(0);
            }
            if (fruits.Count > 0)
            {
                Destroy(fruits[0]);
                fruits.RemoveAt(0);
            }
        }
        for (int i = 0; i < maxItemCount; i++)
        {
            CreateNextItem();
        }
        Destroy(barriers[0]);
        barriers.RemoveAt(0);
        Destroy(fruits[0]);
        fruits.RemoveAt(0);
    }

    void Awake() { instance = this; }
}
