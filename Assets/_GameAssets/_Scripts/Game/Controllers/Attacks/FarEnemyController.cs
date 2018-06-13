using UnityEngine;

public class FarEnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public AudioClip shootClip;
    public float shootForce = 50f;
    public float timeToShot = 10f;
    public float radioToShoot = 40f;

    private Animator _animator;
    private GameObject _player;

    #region UnityFunctions
    void Awake()
    {
        _animator = GetComponentInParent<Animator>();
        _player = GameObject.Find("Player");

        InvokeRepeating("EnemyShoot", timeToShot, timeToShot);
    }

    private void Update()
    {
        SetRotation();
    }
    #endregion

    #region CustomFunctions

    void EnemyShoot()
    {
        float distance = Vector3.Distance(_player.transform.position, this.transform.root.position);
        if (distance <= radioToShoot)
        {
            _animator.Play("shot");

            GameObject enemyBullet = Instantiate(this.bulletPrefab,
                this.transform.position,
                this.transform.rotation);

            Vector3 currentPosition = this.transform.forward;
            currentPosition.y -= 0.02f;
            enemyBullet.GetComponent<Rigidbody>().AddForce(currentPosition * this.shootForce, ForceMode.Impulse);
            AudioSource.PlayClipAtPoint(shootClip, this.transform.position);
        }
    }

    private void SetRotation()
    {
        Vector3 direction = this._player.transform.position - this.transform.root.position;
        Vector3 finalDirection = Vector3.RotateTowards(this.transform.root.forward, direction, 10f, 0);
        transform.root.rotation = Quaternion.LookRotation(finalDirection);
    }

    #endregion
}
