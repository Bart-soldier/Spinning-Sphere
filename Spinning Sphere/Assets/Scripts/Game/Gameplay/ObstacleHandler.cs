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
    public float SpawnInterval = 1.5f; // In seconds
    private float LastSpawn = 0.0f;

    void FixedUpdate()
    {
        if(ObstaclePrefab == null || !active)
        {
            return;
        }

        SpawnObstacle();
    }

    private void SpawnObstacle()
    {
        if (Time.time - LastSpawn >= SpawnInterval)
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
        Vector3 spawnPosition = new Vector3(-3.9f, -1.95f, 0.0f);

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
