using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    public float flashSpeed = 5f;
    public Slider healthBar;
    public Image damageImage;
    public int startingHealth = 100;
    public int currentHealth;
    public Animator anim;

    private PlayerManager playerManager;
    private bool damaged;
    private bool isDead = false;

    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        currentHealth = startingHealth;
    }

    private void Update()
    {
        if (damaged)
            damageImage.color = flashColor;
        else
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        damaged = false;
        
        if (currentHealth <=0 && !isDead)
        {
            isDead = true;
            playerManager.PlayerDied();
            death();
        }
        if (isDead && !PlayerManager.SharedInstance.IsDead)
            playerManager.PlayerDied();
    }

    public void RecieveDamage(int damage)
    {
        damaged = true;
        currentHealth -= damage;
        healthBar.value -= damage;
        if (currentHealth <= 0)
        {
            isDead = true;
            playerManager.PlayerDied();
            death();
        }    
    }

    private void death()
    {
        ObjectSpawner.Deactivate();
        GameObject sound = ObjectPooler.SharedInstance.GetPooledObject("PlayerDeathScream");
        if (sound != null)
        {
            sound.transform.position = transform.position;
            sound.transform.rotation = transform.rotation;
            sound.SetActive(true);
        }
        anim.SetBool("isDead", true);
        MusicManager.SharedInstance.ChangeSong("DeathSong", 1f);
        EnableButtonsOnDeath.EnableButtons();
    }

}