using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars_Manager : MonoBehaviour
{
    [Header("Instantiate")]
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private float spawnTimer = 5f;
    [SerializeField] private GameObject[] cars;

    private float count = 3f;

    void Update()
    {
        count -= Time.deltaTime;
        count = Mathf.Clamp(count, 0f, Mathf.Infinity);
        if(count == 0)
        {
            StartCoroutine("SpawnCars");
            count = spawnTimer;
        }
    }

    private IEnumerator SpawnCars()
    {
        int carNum = Random.Range(0, cars.Length);
        int pointNum = Random.Range(0, spawnPoints.Length);
        var currCar = Instantiate(cars[carNum], spawnPoints[pointNum].transform.position, Quaternion.identity);
        var offset = new Vector3(-90, 0, -90);
        var offset2 = new Vector3(-90, 0, 90);
        if(carNum == 0)
            currCar.transform.Rotate(offset2);
        else
            currCar.transform.Rotate(offset);
        yield return new WaitForSeconds(spawnTimer);
    }


}
