using UnityEngine;

public class GolemAttackController : GolemEntity
{
    private int _maxEnemies = 10;
    private int _currentEnemies = 0;
    private float _minLife = 100;    

    void Awake()
    {
        this._animation = GetComponentInChildren<Animation>();
        this._audioSource = GetComponent<AudioSource>();
        this._playerLife = FindObjectOfType<PlayerLifeController>();
        this._enemyLifeController = GetComponent<EnemyLifeController>();
        this._randomMovement = GetComponent<RandomMovement>();
        this._followMovement = GetComponent<FollowMovement>();
        this._smartEnemyMovement = GetComponent<SmartEnemyMovement>();
        this._fireBallSpawnsController = FindObjectsOfType<FireBallSpawnController>();
        this._shield = GameObject.Find("Shield");
        this._shield.SetActive(false);
        this._bossPortal = GameObject.FindGameObjectWithTag("BossPortal");
        this.EnabledOrDisabledFireBallsSpawn();
    }

    void Update()
    {
        Attack();
    }

    #region Custom Methods
    void Attack()
    {
        if (GlobalActions.IsBossDead 
            && GlobalActions.BossDrop 
            && GlobalActions.PlayerHasStone)
            return;

        float distance = 10f;
        if (this._playerLife != null)
            distance = Vector3.Distance(this.transform.position, this._playerLife.transform.position);

        if (this._enemyLifeController.currentLife <= 0 
            && !GlobalActions.IsBossDead
            && !GlobalActions.BossDrop)
        {
            ActivateDeadAnimation();

            this._randomMovement.enabled = false;
            this._followMovement.enabled = false;
            this._smartEnemyMovement.enabled = false;

            this._shield.SetActive(false);
            this.EnabledOrDisabledFireBallsSpawn();

            DropInterdimentionalStone();

            GlobalActions.BossDrop = true;
            GlobalActions.IsBossDead = true;
        }
        else if (!GlobalActions.IsBossDead)
        {
            SetAttackByCurrentLife(distance);
        }
    }
    
    private void SetAttackByCurrentLife(float distance)
    {
        this.ActivateWalkAnimation();
        this.ActivateMovements();

        bool isTimeToAttack = Time.time > this._amountRateAttack;
        if (distance <= this.distanceToAttack
            && this._enemyLifeController.currentLife > this.CalculateMinLifeByMaxLife()
            && isTimeToAttack)
        {
            this._amountRateAttack = Time.time + this.attackSpeed;
            this.ActivateFirtsAttackAnimation();
            this.DesactivateMovements();
            this._playerLife.ReceiveDamage(damage);
        }
        else if (this._enemyLifeController.currentLife < this.CalculateMinLifeByMaxLife() &&
            this._enemyLifeController.currentLife > _minLife)
        {
            ActivateRageAnimation();
            SetRotation();
            this._shield.SetActive(true);
            this.DesactivateMovements();

            this.EnabledOrDisabledFireBallsSpawn(true);            
        }
        else if (this._enemyLifeController.currentLife < _minLife)
        {            
            this._shield.SetActive(false);
            this.EnabledOrDisabledFireBallsSpawn(false);

            this.ActivateMovements();
            ActivateSecondAttackAnimation();
            SpawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        if(_currentEnemies <= _maxEnemies)
        {
            _currentEnemies++;
            SpawnGameObjects(this.enemySpawnPrefab, _bossPortal.transform.position);
        }
    }

    private void SetRotation()
    {
        Vector3 direction = this._playerLife.transform.position - this.transform.position;
        Vector3 finalDirection = Vector3.RotateTowards(this.transform.forward, direction, 10f, 0);
        transform.rotation = Quaternion.LookRotation(finalDirection);
    }

    private void ActivateMovements()
    {
        this._smartEnemyMovement.enabled = true;
        this._randomMovement.enabled = true;
        this._followMovement.enabled = true;
    }

    private void DesactivateMovements()
    {
        this._smartEnemyMovement.enabled = false;
        this._randomMovement.enabled = false;
        this._followMovement.enabled = false;
    }

    float CalculateMinLifeByMaxLife()
    {
        return this._enemyLifeController.maxLife / 2;
    }

    void ActivateWalkAnimation()
    {
        this._animation.CrossFade("walk");
    }

    void ActivateFirtsAttackAnimation()
    {
        this._animation.CrossFade("hit");
    }

    void ActivateSecondAttackAnimation()
    {
        this._animation.CrossFade("hit2");
    }

    void ActivateDeadAnimation()
    {
        this._animation.CrossFade("die");
    }

    void ActivateRageAnimation()
    {
        this._animation.CrossFade("rage");
    }

    void EnabledOrDisabledFireBallsSpawn(bool enable = false)
    {
        this._fireBallSpawnsController = FindObjectsOfType<FireBallSpawnController>();
        foreach (FireBallSpawnController fireBallSpawnController in _fireBallSpawnsController)
        {
            fireBallSpawnController.enabled = enable;
        }
    }

    private void DropInterdimentionalStone()
    {
        Vector3 enemyPosition = this.transform.position;
        enemyPosition.y += 10f;
        SpawnGameObjects(this.InterdimentionalStonePrefab, enemyPosition);
    }

    private void SpawnGameObjects(GameObject gameObject, Vector3 spawnPosition)
    {
        Instantiate(gameObject, spawnPosition, Quaternion.identity);
    }
    #endregion
}
