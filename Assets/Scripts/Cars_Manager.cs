using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars_Manager : MonoBehaviour
{
    #region Events
    public delegate void ChangeSpeed(float speed);
    public event ChangeSpeed changeSpeed;
    #endregion


    [Header("Instantiate")]
    [SerializeField] private GameObject[] spawnPoints;
    public float spawnTimer = 5f;
    public float carSpeed = 8f;
    [SerializeField] private GameObject[] cars;

    private float count = 0.1f;

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

    #region Debugging options
    public void VehiclesSpeed(float speed)
    {
        carSpeed = speed;
        changeSpeed?.Invoke(speed);
    }

    public void VehiclesSpawn(float spawn)
    {
        spawnTimer = spawn;
        count = spawn;
    }

    #endregion

}
