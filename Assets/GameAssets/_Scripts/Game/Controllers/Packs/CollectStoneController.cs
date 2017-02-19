using UnityEngine;

public class CollectStoneController : MonoBehaviour {

    public float radioToCollect = 5f;
    public AudioClip collectStoneClip;

    private GameObject _player;

	void Awake () {
        _player = GameObject.Find("Player");
	}
	
	void Update () {
        float distance = Vector3.Distance(_player.transform.position, this.transform.position);
        if(distance <= radioToCollect)
        {
            GlobalActions.PlayerHasStone = true;
            if(collectStoneClip != null)
                AudioSource.PlayClipAtPoint(collectStoneClip, this.transform.position, 1f);
            Destroy(this.gameObject);
        }
	}
}
