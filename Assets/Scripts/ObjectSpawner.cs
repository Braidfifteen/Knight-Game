using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private static bool isActive;
    private int bombChosenInt = 5;

    // For now 10 is default difficultyInt and it will decrease based off of time played.
    // 20f is default spawn time and will also decrease
    private int difficultyInt = 10;
    private float difficultySpawnTime = 20f;

    // I can write code to do this automatically
    private int goodItemIndex = 0;
    private int bombIndex = 1;

    private Vector2 spawnPos;
    private Vector2 defaultPos;

    private bool megaBombDrop = false;
    private int megaBombDropCount = 0;

    public float spawnTime;
    public float spawnTimer = 0.0f;
    public float timePlaying;
    public string[] objectsToSpawnTags;

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

    void Start()
    {
        ObjectSpawner.isActive = true;
        defaultPos = transform.position;
    }

    private void Update()
    {
        timePlaying = Time.timeSinceLevelLoad;

        if (ObjectSpawner.isActive && !PlayerManager.SharedInstance.IsDead)
        {
            if (megaBombDrop && megaBombDropCount > 0)
                spawnMegaBombDrop();
            else if (megaBombDrop && megaBombDropCount <= 0)
            {
                megaBombDrop = false;
            }
            if (!megaBombDrop)
            {
                getDifficulty(timePlaying);
                spawnItemsNormal();
            }
        }
    }

    private void spawnMegaBombDrop()
    {
        spawnTime = Random.Range(0.1f, 1f);
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnTime)
        {
            GameObject bomb = ObjectPooler.SharedInstance.GetPooledObject(objectsToSpawnTags[bombIndex]);
            if (bomb != null)
            {
                spawnPos = defaultPos;
                spawnPos.x += randomXSpawn();
                bomb.transform.position = spawnPos;
                bomb.transform.rotation = transform.rotation;
                bomb.transform.parent = transform;
                bomb.SetActive(true);
                megaBombDropCount -= 1;
            }
            spawnTimer = 0.0f;
        }
    }

    private void checkForMegaBombDrop()
    {
        if (Random.Range(0, 50) == 5)
        {
            megaBombDrop = true;
            megaBombDropCount = 10;
        }
    }

    private void spawnItemsNormal()
    {
        spawnTime = Random.Range(0.0f, difficultySpawnTime);
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnTime)
        {
            checkForMegaBombDrop();

            int randomInt = Random.Range(0, difficultyInt);
            int chosenIndex = (randomInt != bombChosenInt) ? goodItemIndex : bombIndex;

            GameObject newObject = ObjectPooler.SharedInstance.GetPooledObject(objectsToSpawnTags[chosenIndex]);
            if (newObject != null)
            {
                spawnPos = defaultPos;
                spawnPos.x += randomXSpawn();
                newObject.transform.position = spawnPos;
                newObject.transform.rotation = transform.rotation;
                newObject.transform.parent = transform;
                newObject.SetActive(true);
                if (newObject.tag == "Bomb")
                {
                    newObject.GetComponent<BombCollision>().DamageToScore = Random.Range(1, 11);
                    spawnExtraBomb();
                }
            }
            spawnTimer = 0.0f;
        }
    }

    private void getDifficulty(float timePlaying)
    {
        if (timePlaying > 45f)
        {
            difficultyInt = 6;
            difficultySpawnTime = 3f;
        }            
        else if (timePlaying > 35f)
        {
            difficultyInt = 7;
            difficultySpawnTime = 10f;
        }
        else if (timePlaying > 25f)
        {
            difficultyInt = 8;
            difficultySpawnTime = 15f;
        }
        else if (timePlaying > 15f)
        {
            difficultyInt = 9;
            difficultySpawnTime = 18f;
        }
    }

    private void spawnExtraBomb()
    {
        bool spawnBomb = false;
        
        switch(difficultyInt)
        {
            case 10:
                if (difficultyInt == Random.Range(0, 11))
                    spawnBomb = true;
                break;
            case 9:
                if (difficultyInt == Random.Range(0, 10))
                    spawnBomb = true;
                break;
            case 8:
                if (difficultyInt == Random.Range(2, 9))
                    spawnBomb = true;
                break;
            case 7:
                if (difficultyInt == Random.Range(5, 8))
                    spawnBomb = true;
                break;
            case 6:
                if (difficultyInt == Random.Range(5, 7))
                    spawnBomb = true;
                break;
        }

        if (spawnBomb)
        {
            GameObject extraBomb = ObjectPooler.SharedInstance.GetPooledObject(objectsToSpawnTags[bombIndex]);
            if (extraBomb != null)
            {
                spawnPos = defaultPos;
                extraBomb.GetComponent<BombCollision>().DamageToScore = 10;
                spawnPos.y += Random.Range(0, 5f);
                spawnPos.x += randomXSpawn();
                extraBomb.transform.parent = transform;
                extraBomb.transform.position = spawnPos;
                extraBomb.transform.rotation = transform.rotation;
                extraBomb.SetActive(true);
            }
        }
    }

    private float randomXSpawn()
    {
        return Random.Range(1.0f, 16f);
    }
}