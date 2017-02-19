using UnityEngine;

public class ReloadEntity : MonoBehaviour
{
    public int quantityPointsToGain = 10;
    public float radioToCatch = 5;
    public float rotationSpeed = 3;
    public float reloadEffectVolumen = 1;
    public AudioClip gainedPointsClip;

    public void Rotate()
    {
        Vector3 rotation = new Vector3(5, 10, 15) * rotationSpeed * Time.deltaTime;
        this.transform.Rotate(rotation);
    }
}
