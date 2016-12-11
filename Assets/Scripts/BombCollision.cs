using UnityEngine;

public class BombCollision : MonoBehaviour
{
    private int damageToPlayer = 20;
    private int damageToScore = 1;
    private HealthScript playerHealth;
    private float bombTransformOffset = 0.10f;

    public int DamageToPlayer { get { return damageToPlayer; } set { damageToPlayer = value; } }
    public int DamageToScore { get { return damageToScore; } set { damageToScore = value; } }

    void OnEnable()
    {
        playerHealth = FindObjectOfType<HealthScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerHealth.RecieveDamage(damageToPlayer);
        }
        if (other.tag == "Bag")
        {
            ScoreManager.DecreaseScore(damageToScore);
            print("Gib on collide with gooditems - bombcollision");
        }

        GameObject explosion = ObjectPooler.SharedInstance.GetPooledObject("Explosion");
        if (explosion != null)
        {
            explosion.transform.position = new Vector3(transform.position.x, transform.position.y - bombTransformOffset);
            explosion.transform.rotation = transform.rotation;
            explosion.SetActive(true);
        }
        gameObject.SetActive(false);
    }
}
