using UnityEngine;

public class GrenadeController : MonoBehaviour
{
    #region Public Variables
    public int damage = 10;
    public float grenadeExplotionVolumen = 0.500f;

    public float lifeTime = 3;
    public float damageRadio = 5;

    public GameObject grenadeExplotionPrefab;
    public AudioClip grenadeExplitionClip;
    #endregion

    private void Start()
    {
        Invoke("Explode", lifeTime);
    }

    private void Explode()
    {
        InstanciateAndDestroyPrefab();
        FindAndDamageEnemies();
        AudioSource.PlayClipAtPoint(grenadeExplitionClip, this.transform.position, grenadeExplotionVolumen);
        Destroy(this.gameObject);
    }

    #region Custom Methods
    private void FindAndDamageEnemies()
    {
        EnemyLifeController[] enemiesLife = FindObjectsOfType<EnemyLifeController>();
        for (int i = 0; i < enemiesLife.Length; i++)
        {
            EnemyLifeController enemyLife = enemiesLife[i];
            DamageEnemy(enemyLife);
        }
    }

    private void DamageEnemy(EnemyLifeController enemyLife)
    {
        float distance = Vector3.Distance(this.transform.position, enemyLife.transform.position);
        if (distance <= damageRadio)
        {
            enemyLife.ReceiveDamage(damage);
        }
    }

    private void InstanciateAndDestroyPrefab()
    {
        GameObject explotion = Instantiate(grenadeExplotionPrefab);
        explotion.transform.position = this.transform.position;
        Destroy(explotion, lifeTime);
    }
    #endregion    
}
