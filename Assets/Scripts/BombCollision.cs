using UnityEngine;

public class BombCollision : MonoBehaviour
{
    private int damageToPlayer = 20;
    private int damageToScore = 1;
    private HealthScript playerHealth;
    private float bombTransformOffset = 0.10f;
    private float spawnRadius = 1f;
    private float explosiveForce = 10f;

    public int DamageToPlayer { get { return damageToPlayer; } set { damageToPlayer = value; } }
    public int DamageToScore { get { return damageToScore; } set { damageToScore = value; } }

    void OnEnable()
    {
        playerHealth = FindObjectOfType<HealthScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject explosion = ObjectPooler.SharedInstance.GetPooledObject("Explosion");
        if (explosion != null)
        {
            explosion.transform.position = new Vector3(transform.position.x, transform.position.y - bombTransformOffset);
            explosion.transform.rotation = transform.rotation;
            explosion.SetActive(true);
        }
        gameObject.SetActive(false);

        if (other.tag == "Player")
        {
            playerHealth.RecieveDamage(damageToPlayer);
            ScoreManager.DecreaseScore(3);
        }
        if (other.tag == "Bag")
        {
            ScoreManager.DecreaseScore(damageToScore);
            gibOnBagCollision();
        }
    }

    private void gibOnBagCollision()
    {
        for (int i = 0; i < damageToScore; i++)
        {
            GameObject gib = ObjectPooler.SharedInstance.GetPooledObject("GoodItemExploded");
            if (gib != null)
            {
                gib.transform.position = transform.position + Random.insideUnitSphere * spawnRadius;
                gib.transform.rotation = transform.rotation;
                gib.SetActive(true);
                addExplosionForce2D(gib.GetComponent<Rigidbody2D>(), explosiveForce * 100, transform.position, spawnRadius);
            }
        }
    }

    private void addExplosionForce2D(Rigidbody2D rb, float force, Vector3 expPos, float radius)
    {
        Vector3 direction = (rb.transform.position - expPos);
        float calc = 1 - (direction.magnitude / radius);
        if (calc <= 0)
            calc = 0;
        rb.AddForce(direction.normalized * force * calc);
    }
}
