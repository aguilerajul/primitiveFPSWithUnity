using UnityEngine;

public class EnemyGeneratorEntity : MonoBehaviour
{
    #region Public Variables
    public int MaxEnemies = 10;
    public float TimeToGenerate = 1;
    public float Radio = 6f;
    public float SpawnHeight = 2f;
    public float PlayerDistanceToGenerate = 50f;

    public GameObject EnemyPrefab;
    #endregion

    #region Private Variables
    protected int _currentEnemiesGeneratedCount = 0;
    protected bool _generateNewEnemies = true;
    protected GameObject _player;
    #endregion
}
