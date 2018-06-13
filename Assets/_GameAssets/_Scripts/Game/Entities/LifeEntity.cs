using UnityEngine;

public class LifeEntity : MonoBehaviour
{
    public AudioClip hurtAudioClip;
    public float timeToDestroyPrefab = 1f;
    public float maxLife;
    public float currentLife { get; protected set; }
}
