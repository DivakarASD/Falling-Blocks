using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlocksSpawner : MonoBehaviour
{
    public GameObject FallingBlockPrefab;
    Vector2 screenHalfSize;
    public float secondsBetweenSpawn = 1f;
    float nextSpawnTime;
    public Vector2 minMaxSpawnSize; //x holds the minimum value and y holds the maximum value .Easy way to take in the min and max values in one variable.
    public float spawnAngleMax;
    public Vector2 secondsBetweenSpawnMinAndMax;
    // Start is called before the first frame update
    void Start()
    {
        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);       
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawnTime)
        {
            secondsBetweenSpawn = Mathf.Lerp(secondsBetweenSpawnMinAndMax.y, secondsBetweenSpawnMinAndMax.x, Difficulty.GetDifficulty());
            print(nextSpawnTime);
            nextSpawnTime = Time.timeSinceLevelLoad + secondsBetweenSpawn;
            float spawnSize = Random.Range(minMaxSpawnSize.x, minMaxSpawnSize.y);
            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSize.x, screenHalfSize.x), screenHalfSize.y +spawnSize);
            GameObject newBlock=(GameObject) Instantiate(FallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward*spawnAngle));
            newBlock.transform.localScale = Vector2.one * spawnSize;
        }
        
    }
    
}
