using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksSpawner : MonoBehaviour
{
    [SerializeField]
    private Brick[] bricks;
    private List<Brick> spawnedBricks;

    [SerializeField]
    private float bricksDiameter = 0.7f;
    private byte spawnLenth = 7;
    private int rowsSpawned;

    
    private void Start()
    {
        spawnedBricks = new List<Brick>();
        SpawnRowOfBricks();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OmitBricks(true);
        }
    }
    public void SpawnRowOfBricks()
    {
        rowsSpawned++;

        float spawnChance = Random.Range(1f / 7f, 6f / 7f);
        List<Brick> rowOfBricks = new List<Brick>();

        for (byte i = 0; i < spawnLenth; i++)
        {
            if (Random.value < spawnChance)
            {
                Vector3 spawnPosition = transform.position + Vector3.right * i * bricksDiameter;
                Brick brick = SpawnBrick(spawnPosition);
                
                rowOfBricks.Add(brick);
            }
        }

        if (rowOfBricks.Count == 0)
        {
            Vector3 spawnPosition = transform.position;
            spawnPosition += Vector3.right * Random.Range(0, spawnLenth) * bricksDiameter;
            Brick brick = SpawnBrick(spawnPosition);
            rowOfBricks.Add(brick);
        }
        else if (rowOfBricks.Count == spawnLenth)
        {
            int index = Random.Range(0, spawnLenth);
            Destroy(rowOfBricks[index].gameObject);
            rowOfBricks.RemoveAt(index);
        }

        foreach (Brick brick in rowOfBricks)
        {
            spawnedBricks.Add(brick);
        }
    }

    private Brick SpawnBrick(Vector3 spawnPosition)
    {
        int index = Random.Range(0, bricks.Length);
        Brick brick = Instantiate(bricks[index], spawnPosition, Quaternion.identity);
        brick.HealthPoints = rowsSpawned;
        return brick;
    }

    public void OmitBricks(bool spawnNewRow)
    {
        foreach (Brick brick in spawnedBricks)
        {
            brick.transform.position -= Vector3.up * bricksDiameter;
        }

        if (spawnNewRow)
        {
            SpawnRowOfBricks();
        }
    }
}
