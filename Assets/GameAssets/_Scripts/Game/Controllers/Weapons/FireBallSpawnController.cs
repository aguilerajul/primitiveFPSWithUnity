using UnityEngine;

public class FireBallSpawnController : MonoBehaviour
{
    public float fireBallMinForce = 10f;
    public float fireBallMaxForce = 60f;
    public float fireBallMinPosition = 20f;
    public float fireBallMaxPosition = 30f;
    public float fireBallAttackSpeed = 5f;
    public float timeToChangePosition = 4f;
    public float fireBallMovementSpeed = 0.05f;
    public GameObject fireBallPrefab;

    private void Start()
    {
        InvokeRepeating("ThrowFireBall", fireBallAttackSpeed, fireBallAttackSpeed);
        InvokeRepeating("ChangePosition", timeToChangePosition, timeToChangePosition);
    }

    public void CancelInvokeRepeating()
    {
        CancelInvoke("ThrowFireBall");
    }

    private void ChangePosition()
    {
        float randomPosition = Random.Range(fireBallMinPosition, fireBallMaxPosition);

        Vector3 newEnemyPosition = this.transform.localPosition;
        newEnemyPosition.x = randomPosition;
        this.transform.localPosition = newEnemyPosition;
    }

    private void ThrowFireBall()
    {
        GameObject fireBall = Instantiate(this.fireBallPrefab, this.transform.position, this.transform.rotation);
        Rigidbody fireBallRigidBody = fireBall.GetComponent<Rigidbody>();
        float forceRange = Random.Range(fireBallMinForce, fireBallMaxForce);
        fireBallRigidBody.AddForce(this.transform.forward * forceRange, ForceMode.Impulse);
    }
}
