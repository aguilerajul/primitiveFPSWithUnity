using UnityEngine;

public class BulletController : MonoBehaviour
{
    #region Public Variables
    public int damagePerHit = 1;
    public float lifeCicle = 10;
    public GameObject explotionBulletPrefab;
    #endregion
    
    void Start()
    {
        Destroy(this.gameObject, lifeCicle);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy" || collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<LifeController>().ReceiveDamage(damagePerHit);
        }

        GameObject explotion = Instantiate(explotionBulletPrefab, this.transform.position, Quaternion.identity);
        Destroy(explotion, 4);

        Destroy(this.gameObject);
    }
}
