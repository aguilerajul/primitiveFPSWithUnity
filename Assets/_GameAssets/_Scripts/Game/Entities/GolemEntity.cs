using UnityEngine;

public class GolemEntity : MonoBehaviour
{
    #region Public Variables
    public int damage = 7;

    public float distanceToAttack = 7f;
    public float rageSpeed = 7f;
    public float attackSpeed = 1f;

    public AudioClip firstAttackClip;
    public AudioClip secondAttackClip;
    public AudioClip rageClip;

    public GameObject InterdimentionalStonePrefab;
    public GameObject enemySpawnPrefab;
    #endregion

    #region Protected Variables
    protected float _amountRateAttack;
    protected float _amountRateFireballAttack;

    protected Animation _animation;
    protected AudioSource _audioSource;
    protected PlayerLifeController _playerLife;
    protected EnemyLifeController _enemyLifeController;
    protected RandomMovement _randomMovement;
    protected FollowMovement _followMovement;
    protected SmartEnemyMovement _smartEnemyMovement;
    protected GameObject _bossPortal;

    protected FireBallSpawnController[] _fireBallSpawnsController;
    protected GameObject _shield;
    #endregion
}
