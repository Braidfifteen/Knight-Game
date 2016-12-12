using UnityEngine;

public class ItemCollisions : MonoBehaviour
{
    private HealthScript health;

    void OnEnable()
    {
        health = FindObjectOfType<HealthScript>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            health.RecieveDamage(10);
            GameObject sound = ObjectPooler.SharedInstance.GetPooledObject("PlayerHitSound");
            if (sound != null)
            {
                sound.transform.position = transform.position;
                sound.transform.rotation = transform.rotation;
                sound.SetActive(true);
            }
            gameObject.SetActive(false);
        }
        else if (col.tag == "Bag")
        {
            ScoreManager.AddToScore(1);
            //GameObject sound = ObjectPooler.SharedInstance.GetPooledObject("ItemCatchedSound");
            //if (sound != null)
            //{
            //    sound.transform.position = transform.position;
            //    sound.transform.rotation = transform.rotation;
            //    sound.SetActive(true);
            //}
            gameObject.SetActive(false);
        }
        else if (col.tag == "Ground")
        {
            gameObject.SetActive(false);
        }
        else if (col.tag == "GoodItem" || col.tag == "BadItem")
        {
            gameObject.SetActive(false);
        }
    }
}
