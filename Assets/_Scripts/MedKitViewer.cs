using UnityEngine;
using UnityEngine.Serialization;

sealed class MedKitViewer : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private MedKitBar _medKitBar;
    [SerializeField] private uint _numberOfMedKits;
    private bool _full;
    private bool _empty;
    
    void Start()
    {
        _medKitBar.SetMedKitCount(_numberOfMedKits);
    }

    
    void Update()
    {
        FullOrEmptyChecker();
        
        if (Input.GetKeyDown(KeyCode.O))
        {
            PickUpMedKit(); 
        }

        else if (Input.GetKeyDown(KeyCode.P))
        {
            UseMedKit();
        }
    }
    
    private void UseMedKit()
    {
        if (_playerStats._IsAtMaxHealth)
        {
            print("Your health is already at maximum.");
            return;
        }

        if (_empty)
        {
            print("You have no Med Kits to use.");
            return;
        }
        
        _numberOfMedKits -= 1;
        print("You have successfully gained full health.");
        _playerStats.GainHealth();
        UpdateMedKitBar();
    }

    
    private void PickUpMedKit()
    {
        if (_full)
        {
            print("Your Med Kit inventory is already full.");
            return;
        }
        
        _numberOfMedKits += 1;
        print("A Med Kit has been picked up.");
        UpdateMedKitBar();
    }
    
    private void FullOrEmptyChecker()
    {
        switch (_numberOfMedKits)
        {
            case 0:
                _full = false;
                _empty = true;
                break;
            case 3:
                _full = true;
                _empty = false;
                break;
            default:
                _full = false;
                _empty = false;
                break;
        }
    }
    
    private void UpdateMedKitBar()
    {
        _medKitBar.SetMedKitCount(_numberOfMedKits);
    }
}
