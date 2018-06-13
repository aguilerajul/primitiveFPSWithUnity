using UnityEngine;

public class EnemyGenaratorController : EnemyGeneratorEntity
{ 
    void Awake()
    {
        this._player = GameObject.Find("Player");
    }

    void Update()
    {
        if (this._player == null)
            return;

        float distance = Vector3.Distance(this.transform.position, _player.transform.position);
        if (this._generateNewEnemies && distance < this.PlayerDistanceToGenerate)
        {
            this._generateNewEnemies = false;
            InvokeRepeating("GenerateEnemy", TimeToGenerate, TimeToGenerate);
        }
    }

    #region Custom Methods
    void GenerateEnemy()
    {
        SetEnemyPosition();
        ValidateMaxEnemiesAndCancelInvoke();
    }

    private void ValidateMaxEnemiesAndCancelInvoke()
    {
        _currentEnemiesGeneratedCount += 1;
        if (_currentEnemiesGeneratedCount == MaxEnemies)
        {
            CancelInvoke("GenerateEnemy");
        }
    }

    private void SetEnemyPosition()
    {
        Vector3 newEnemyPosition = this.transform.position;
        Vector2 randomPointInCircle = Random.insideUnitCircle * Radio;
        newEnemyPosition += new Vector3(randomPointInCircle.x, this.SpawnHeight, randomPointInCircle.y);

        GameObject newEnemy = Instantiate(this.EnemyPrefab);
        newEnemy.transform.position = newEnemyPosition;
    }

    public bool IsEnemyGenerated()
    {
        return !this._generateNewEnemies;
    }
    #endregion    
}
