using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private static bool isActive;
    public float spawnTime;
    public float spawnTimer = 0.0f;

    void Start()
    {
        ObjectSpawner.isActive = true;
    }

    private void Update()
    {
        if (ObjectSpawner.isActive)
        {
            spawnTime = Random.Range(0.0f, 22.0f);
            spawnTimer += Time.deltaTime;
            if (spawnTimer > spawnTime)
            {
                Vector2 spawnPos = transform.position;
                spawnPos.x += Random.Range(1.0f, 16f);
                GameObject newObject = ObjectPooler.SharedInstance.GetPooledObject("GoodItem");
                if (newObject != null)
                {
                    newObject.transform.position = spawnPos;
                    newObject.transform.rotation = transform.rotation;
                    newObject.transform.parent = transform;
                    newObject.SetActive(true);
                }
                spawnTimer = 0.0f;
            }
        }
    }

    public static void Deactivate()
    {
        if (ObjectSpawner.isActive)
            ObjectSpawner.isActive = false;
    }

    public static void Activate()
    {
        if (!ObjectSpawner.isActive)
            ObjectSpawner.isActive = true;
    }
}