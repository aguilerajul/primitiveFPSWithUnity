using UnityEngine;

public class EnemyAttackEntity : MonoBehaviour {
    #region Public Variables
    public int Damage = 1;

    public float DistanceToExplode = 5f;
    public float TimeToDestroyPreFab = 3f;

    public GameObject ExplotionPrefab;
    public AudioClip EnemyInmolateExplotionClip;
    #endregion

    #region Private Variables
    protected PlayerLifeController _playerLife;
    protected EnemyLifeController _enemyLifeController;
    #endregion
}
