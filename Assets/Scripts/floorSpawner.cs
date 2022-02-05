using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorSpawner : MonoBehaviour
{
    [SerializeField] GameObject tile;
    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject refObj;
    [SerializeField] GameObject coin;
    private float timeOffset = 0.2f;

    private float randomVal = 0.8f;
    private float randomVal2 = 0.8f;
    private float randomVal3 = 0.6f;

    public float distance = 8f;
    public float longerDist = 18f;

    private float ylength = 0.1f;
    private float zlength = 4f;
    private Vector3 prevTilePos;
    private float startTime;
    private Vector3 direction;
    private Vector3 mainDir = new Vector3(0, 0, 1);
    private Vector3 otherDir = new Vector3(1, 0, 0);
    private bool rotateCoin, rotateObstacle;

    // Start is called before the first frame update
    void Start()
    {
        prevTilePos = refObj.transform.position;
        startTime = Time.time;
        rotateCoin = false;
        rotateObstacle = false;

        obstacle.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        coin.transform.rotation = Quaternion.Euler(90f, 90f, 90f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time - startTime > timeOffset) {
            float x = Random.value;
            float y = Random.value;
            float z = Random.value;
            float w = Random.value;

            if (x < randomVal)
            {
                direction = mainDir;
            }
            else
            {
                Vector3 temp = direction;
                direction = otherDir;
                mainDir = direction;
                otherDir = temp;

                rotateObstacle = true;
                rotateCoin = true;
            }

            if (y < randomVal2)
            {
                Vector3 spawnPos = prevTilePos + distance * direction;
                startTime = Time.time;
                Instantiate(tile, spawnPos, Quaternion.Euler(0, 0, 0));
                if (w < randomVal3)
                {
                    coin.transform.rotation *= Quaternion.Euler(0f, 0f, 90f);
                }
                Vector3 coinSpawn = new Vector3(spawnPos.x, spawnPos.y + 2, spawnPos.z);
                Instantiate(coin, coinSpawn, coin.transform.rotation);
                prevTilePos = spawnPos;
                tile.transform.localScale = new Vector3(1, 1, 1);
                
            }
            else {
                Vector3 spawnPos = prevTilePos + longerDist * direction * 2;
                startTime = Time.time;
                Instantiate(tile, spawnPos, Quaternion.Euler(0, 0, 0));
                prevTilePos = spawnPos;
                tile.transform.localScale = new Vector3(1, 1, 1);
            }

            if (z < randomVal2)
            {
                Vector3 spawnPos = prevTilePos + distance * direction;
                startTime = Time.time;
                Instantiate(tile, spawnPos, Quaternion.Euler(0, 0, 0));
                prevTilePos = spawnPos;
                tile.transform.localScale = new Vector3(1, 1, 1);
            }
            else {
                Vector3 spawnPos = prevTilePos + distance * direction;
                startTime = Time.time;
                Vector3 objSpawn = prevTilePos + distance * direction;
                Instantiate(tile, spawnPos, Quaternion.Euler(0, 0, 0));
                if (rotateObstacle == true)
                {
                    obstacle.transform.rotation *= Quaternion.Euler(0f,90f,0f);
                }
                Instantiate(obstacle, objSpawn, obstacle.transform.rotation);
                prevTilePos = spawnPos;
                tile.transform.localScale = new Vector3(1, 1, 1);
            }
            
        }
        rotateCoin = false;
        rotateObstacle = false;
    }
}
