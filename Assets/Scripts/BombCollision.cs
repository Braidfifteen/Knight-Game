using UnityEngine;

public class BombCollision : MonoBehaviour
{
    public int damageToPlayer = 20;
    public int damageToScore;
    private HealthScript playerHealth;
    private float bombTransformOffset = 0.10f;

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
            //gib on collide with gooditems
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

    public void SetDamage(int damageToPlayer, int damageToScore)
    {
        this.damageToPlayer = damageToPlayer;
        this.damageToScore = damageToScore;
    }

    public void SetDamage(int damageToScore)
    {
        this.damageToScore = damageToScore;
    }
}
