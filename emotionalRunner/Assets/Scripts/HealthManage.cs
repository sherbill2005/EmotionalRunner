using System.Collections;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is create

    public int maxHealth = 100;
    private int currentHealth;
    public Slider HealthSlider;
    private PlayerController playerController;
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        currentHealth = maxHealth;
        HealthSlider.maxValue = maxHealth;
        HealthSlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5f)Die();

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HealthSlider.value = currentHealth;
            
        if (currentHealth <= 0) Die(); 

    }

    public void IncreaseHealth(int healthIncrease)
    {
        if (currentHealth == maxHealth) return;
        currentHealth += healthIncrease;
        HealthSlider.value = currentHealth;
        

    }

    private IEnumerator GameoverPanelDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
    public void Die()
    {
        playerController.DeadAnimation();
        
        
        
    }

    public void ShowGameOverUI()
    {
        GameOverUI.instance.Gameover();
        PlayerStats.instance.ADDDeaths();

    }
    
}
