using UnityEngine;

[System.Serializable]
public struct Stats
{
    public int _MaxHealth;
    public Stats(int maxHealth) { _MaxHealth = maxHealth; }
}

sealed class PlayerStats : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Stats _stats;
    [SerializeField] private int _currentHealth;
    public bool _IsAtMaxHealth;

    private void Start()
    {
        _healthBar.SetMaxHealth(_stats._MaxHealth);
        _stats = new(_stats._MaxHealth);
        _currentHealth = _stats._MaxHealth;
    }

    void Update()
    {
        HealthChecker();

        if (Input.GetKey(KeyCode.I))
        {
            TakeDamage(1);
        }
    }

    private void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        UpdateHealthBar();
    }

    public void GainHealth()
    {
        _currentHealth = _stats._MaxHealth;
        UpdateHealthBar();
    }
    
    private void HealthChecker()
    {
        if (_currentHealth <= 0)
        {
            // Some "Game Over" logic here...
        }
        
        if (_currentHealth != _stats._MaxHealth)
        {
            _IsAtMaxHealth = false;
            return;
        }

        if (_currentHealth == _stats._MaxHealth)
        {
            _IsAtMaxHealth = true;
        }
    }

    private void UpdateHealthBar()
    {
        _healthBar.SetHealth(_currentHealth);
    }
    
}