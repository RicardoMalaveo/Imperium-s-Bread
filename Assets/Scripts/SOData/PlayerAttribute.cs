
using UnityEngine;

[CreateAssetMenu]
public class PlayerAttribute : ScriptableObject
{
    [SerializeField]
    private int _playerBaseAttack = 20;
    [SerializeField]
    private int _playerBaseHealth = 100;
    [SerializeField]
    private int _playerCurrentLevel = 1;
    [SerializeField]
    private int _favoursPricePerLevel = 20;
    [SerializeField]
    private int _currentHealth = 100;
    public int playerBaseAttack
    {
        get { return _playerBaseAttack; }
        set { _playerBaseAttack = value; }
    }
    public int playerBaseHealth
    {
        get { return _playerBaseHealth; }
        set { _playerBaseHealth = value; }
    }
    public int playerCurrentLevel
    {
        get { return _playerCurrentLevel; }
        set { _playerCurrentLevel = value; }
    }
    public int favoursPricePerLevel
    {
        get { return _favoursPricePerLevel; }
        set { _favoursPricePerLevel = value; }
    }
    public int currentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }
}
