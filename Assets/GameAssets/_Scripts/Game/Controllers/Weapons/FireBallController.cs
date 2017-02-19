using UnityEngine;

public class FireBallController : MonoBehaviour {

    #region Public Variables
    public int damage = 10;
    public float fireBallVolumen = 0.500f;

    public float lifeTime = 3;
    public float damageRadio = 5;

    public GameObject fireBallExplotionPrefab;
    public AudioClip fireBallExplitionClip;
    #endregion

    private void Start()
    {
        Invoke("Explode", lifeTime);
    }

    private void Explode()
    {
        InstanciateAndDestroyPrefab();
        DamagePlayer();
        AudioSource.PlayClipAtPoint(fireBallExplitionClip, this.transform.position, fireBallVolumen);
        Destroy(this.gameObject);
    }

    #region Custom Methods
    private void DamagePlayer()
    {
        PlayerLifeController playerLife = FindObjectOfType<PlayerLifeController>();
        DamagePlayer(playerLife);
    }

    private void DamagePlayer(PlayerLifeController playerLife)
    {
        float distance = Vector3.Distance(this.transform.position, playerLife.transform.position);
        if (distance <= damageRadio)
        {
            playerLife.ReceiveDamage(damage);
        }
    }

    private void InstanciateAndDestroyPrefab()
    {
        GameObject explotion = Instantiate(fireBallExplotionPrefab);
        explotion.transform.position = this.transform.position;
        Destroy(explotion, lifeTime);
    }
    #endregion
}
