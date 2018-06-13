using UnityEngine;

public abstract class LifeController : LifeEntity
{
    private void Awake()
    {
        this.currentLife = this.maxLife;
    }

    public bool IsDamaged()
    {
        if (this.currentLife < this.maxLife)
            return true;

        return false;
    }

    public void ReceiveDamage(int damage)
    {
        if (this.currentLife > 0)
        {
            if(base.hurtAudioClip != null)
            {
                AudioSource.PlayClipAtPoint(hurtAudioClip, this.transform.position, 1);
            }

            this.currentLife -= damage;
        }

        if (this.currentLife <= 0)
        {
            Die();
        }
    }

    public void Heal(int healPoints)
    {
        currentLife = Mathf.Min(this.currentLife + healPoints, this.maxLife);
    }

    protected abstract void Die();
}
