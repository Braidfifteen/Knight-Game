using UnityEngine;

public class BombCollision : MonoBehaviour
{
    private HealthScript playerHealth;
    private int bombDamage;
    private float bombTransformOffset = 0.10f;

    void OnEnable()
    {
        playerHealth = FindObjectOfType<HealthScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("true");
        if (other.tag == "Player")
        {
            playerHealth.RecieveDamage(20);
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
