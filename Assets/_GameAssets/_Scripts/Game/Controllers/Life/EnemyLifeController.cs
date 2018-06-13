using UnityEngine;

public class EnemyLifeController : LifeController
{
    #region Public Variables
    public AudioClip deathSoundClip;
    public GameObject deathPrefab;
    public GameObject shotGunPrefab;
    public int timeToDestroyExplotionPrefab = 3;
    public int timeToDestroyParentObject = 0;
    #endregion
    

    protected override void Die()
    {
        AudioSource.PlayClipAtPoint(deathSoundClip, this.transform.position, 0.500f);

        if (deathPrefab != null)
        {
            GameObject explotion = Instantiate(deathPrefab, this.transform.position, Quaternion.identity);
            Destroy(explotion, timeToDestroyExplotionPrefab);
        }
        
        GlobalActions.UpdateEnemiesDeadCount();

        DropShotGun();

        Destroy(this.gameObject, timeToDestroyParentObject);
    }

    private void DropShotGun()
    {
        float dropShotGunRandom = Random.Range(5, 15);
        if (shotGunPrefab != null 
            && GlobalActions.GetCurrentEnemiesDead() >= dropShotGunRandom 
            && !GlobalActions.IsShotGunDroped)
        {
            GlobalActions.IsShotGunDroped = true;
            Vector3 enemyPosition = this.transform.position;
            enemyPosition.y += 10f;
            Instantiate(shotGunPrefab, enemyPosition, Quaternion.identity);
        }
    }

    public void Inmolate(AudioClip enemyInmolateExplotionClip)
    {
        if (enemyInmolateExplotionClip != null)
        {
            AudioSource.PlayClipAtPoint(enemyInmolateExplotionClip, this.transform.position, 40);
        }

        GlobalActions.UpdateEnemiesDeadCount();
        Destroy(this.gameObject);
    }
}
