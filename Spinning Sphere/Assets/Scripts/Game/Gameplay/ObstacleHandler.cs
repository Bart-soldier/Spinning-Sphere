using UnityEngine;

#nullable enable

public class ObstacleHandler : MonoBehaviour
{
    public GameObject? ObstaclePrefab;

    private bool active = false;
    public bool Active
    {
        get => active;
        set
        {
            active = value;

            if (active)
            {
                DeactivateAllObstacles();
                LastSpawn = Time.time;
            }
            else
            {
                DissolveAllObstacles();
            }
        }
    }

    public float SpawnInterval = 2.0f; // In seconds
    public int ObstacleSpawnCount = 5;

    private float LastSpawn = 0.0f;
    private readonly float[] SpawnX = { -3.9f,  -1.95f , 0.0f, 1.95f , 3.9f };
    private readonly float[] SpawnY = { -1.95f, -0.975f, 0.0f, 0.975f, 1.95f};
    private bool[,] OccupiedSpawns = new bool[5, 5];

    void FixedUpdate()
    {
        if(ObstaclePrefab == null || !active)
        {
            return;
        }

        SpawnObstacle();
    }

    private static void FillArray(bool[,] array, bool value)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = value;
            }
        }
    }

    private void SpawnObstacle()
    {
        if (Time.time - LastSpawn >= SpawnInterval)
        {
            FillArray(OccupiedSpawns, false);

            for (int i = 0; i < ObstacleSpawnCount; i++)
            {
                GameObject? obstacle = GetDeactivatedObstacle();

                if (obstacle == null)
                {
                    obstacle = Instantiate(ObstaclePrefab!, transform);
                }

                InitializeSpawn(obstacle);
                LastSpawn = Time.time;
            }
        }
    }

    private GameObject? GetDeactivatedObstacle()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            GameObject obstacle = transform.GetChild(i).gameObject;

            if (obstacle.activeSelf == false)
            {
                return obstacle;
            }
        }

        return null;
    }

    private void InitializeSpawn(GameObject obstacle)
    {
        int randomX = 0;
        int randomY = 0;
        bool occupied = false;

        do
        {
            randomX = Random.Range(0, 4);
            randomY = Random.Range(0, 4);
            occupied = OccupiedSpawns[randomX, randomY];
        }
        while (occupied);

        OccupiedSpawns[randomX, randomY] = true;
        Vector3 spawnPosition = new Vector3(SpawnX[randomX], SpawnY[randomY], 0.0f);

        obstacle.SetActive(true);
        obstacle.transform.localPosition = spawnPosition;
        obstacle.GetComponent<TranslateAnimation>().Animate = true;
        obstacle.GetComponent<DissolveAnimation>().DissolveIn();
    }

    private void DissolveAllObstacles()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject obstacle = transform.GetChild(i).gameObject;
            obstacle.GetComponent<TranslateAnimation>().Animate = false;
            obstacle.GetComponent<DissolveAnimation>().DissolveOutIfVisible();
        }
    }

    private void DeactivateAllObstacles()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
