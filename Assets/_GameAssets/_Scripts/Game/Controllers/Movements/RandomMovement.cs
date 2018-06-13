using UnityEngine;

public class RandomMovement : RandomMovementEntity
{
    private void Awake()
    {
        SetMapWidthAndDepth();
        this._characterController = GetComponent<CharacterController>();
        InvokeRepeating("ChangeDirection", 0, this.ChangeDirectionInterval);
    }

    private void Update()
    {
        SetRotation();
        SetMove();
        SetPosition();
    }

    #region Custom Methods
    void SetMapWidthAndDepth()
    {
        Terrain currentTerrain = GameObject.Find("PrincipalTerrain").GetComponent<Terrain>();
        this._mapDepth = currentTerrain.terrainData.size.z;
        this._mapWidth = currentTerrain.terrainData.size.x;
    }

    private void SetRotation()
    {
        float rotationSpeed = this.RotationDegrees * Mathf.Deg2Rad * Time.deltaTime;
        this.transform.forward = Vector3.RotateTowards(this.transform.forward, this._finalDirection, rotationSpeed, 1);
    }

    private void SetMove()
    {
        this._characterController.SimpleMove(this.transform.forward * this.Speed);
    }

    private void SetPosition()
    {
        Vector3 currentPosition = this.transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, 0, this._mapWidth);
        currentPosition.z = Mathf.Clamp(currentPosition.z, 0, this._mapDepth);
        this.transform.position = currentPosition;
    }

    void ChangeDirection()
    {
        Vector2 randomDirection = Random.insideUnitCircle;
        randomDirection.Normalize();

        Vector3 direction = new Vector3(randomDirection.x, 0, randomDirection.y);
        this._finalDirection = direction;
    }
    #endregion
}
