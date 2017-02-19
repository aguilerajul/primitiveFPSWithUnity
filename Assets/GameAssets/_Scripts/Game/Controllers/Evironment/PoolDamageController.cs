using UnityEngine;

public class PoolDamageController : PoolEntity
{
    // Use this for initialization
    void Awake()
    {
        this._playerLife = FindObjectOfType<PlayerLifeController>();
        this._audioSource = GetComponent<AudioSource>();

        this._heightToDamage = this._playerLife.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, this._playerLife.transform.position);
        if (distance <= this.RadioToDamage && GetHeightDistanceFromPlayer() <= this._heightToDamage)
        {
            InvokeRepeating("DamagePlayer", this.TimeToDamageInSeconds, this.TimeToDamageInSeconds);
        }
        else
        {
            CancelInvoke("DamagePlayer");
        }
    }

    float GetHeightDistanceFromPlayer()
    {
        return (this._playerLife.transform.position.y - this.transform.position.y);
    }

    void DamagePlayer()
    {
        if (this.PlayerDamagedClip != null && this._audioSource != null)
        {
            this._audioSource.PlayOneShot(this.PlayerDamagedClip);
        }
        this._playerLife.ReceiveDamage(this.Damage);
    }
}
