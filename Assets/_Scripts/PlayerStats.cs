using UnityEngine;

[System.Serializable]
public struct Stats
{
    public int _MaxHealth;

    public Stats(int maxHealth)
    {
        _MaxHealth = maxHealth;
    }
}

public class PlayerStats : MonoBehaviour
{
    
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Stats _playerStats;
    [SerializeField] private int _currentHealth;


    #region Unity Methods

    private void Start()
    {
        _healthBar.SetMaxHealth(_playerStats._MaxHealth);
        _playerStats = new(_playerStats._MaxHealth);
        _currentHealth = _playerStats._MaxHealth;
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            TakeDamage(1);
        }

        else if (Input.GetKeyDown(KeyCode.L))
        {
            GainHealth();
        }
    }

    #endregion
    
    #region Health Methods

    private void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        UpdateHealthBar();
    }

    private void GainHealth()
    {
        _currentHealth = _playerStats._MaxHealth;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        _healthBar.SetHealth(_currentHealth);
    }

    #endregion
    
}

