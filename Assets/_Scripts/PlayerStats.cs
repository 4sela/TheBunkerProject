using UnityEngine;

[System.Serializable]
public struct Stats
{
    public int MaxHealth;

    public Stats(int maxHealth)
    {
        MaxHealth = maxHealth;
    }
}

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private Stats _playerStats;
    [SerializeField] private int _currentHealth;

    void Start()
    {
        _playerStats = new(100);
        _currentHealth = _playerStats.MaxHealth;
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        // UpdateHealthBar();
    }

    private void GainHealth()
    {
        _currentHealth = _playerStats.MaxHealth;
        // UpdateHealthBar();
    }

    // private void UpdateHealthBar()
    // {
    //     healthbar.value = _currentHealth;
    // }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(2);
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            GainHealth();
        }
    }
}


