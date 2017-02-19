using UnityEngine;

public class EnemyAttackController : EnemyAttackEntity
{
    private void Awake()
    {
        this._playerLife = FindObjectOfType<PlayerLifeController>();
        this._enemyLifeController = GetComponent<EnemyLifeController>();
    }

    private void Update()
    {
        Attack();
    }

    #region Custom Methods
    private void Attack()
    {
        float distance = Vector3.Distance(this.transform.position, _playerLife.transform.position);
        if (distance < this.DistanceToExplode)
        {
            GameObject explotion = Instantiate(this.ExplotionPrefab, this.transform.position, Quaternion.identity);
            Destroy(explotion, this.TimeToDestroyPreFab);

            _playerLife.ReceiveDamage(this.Damage);
            _enemyLifeController.Inmolate(this.EnemyInmolateExplotionClip);
        }
    }
    #endregion
}
