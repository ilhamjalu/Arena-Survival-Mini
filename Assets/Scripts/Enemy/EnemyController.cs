using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable, ITeamMember
{
    [SerializeField] Health health;
    [SerializeField] MovementModel movementModel;
    [SerializeField] EnemyAttack enemyAttack;
    [SerializeField] Transform target;
    [SerializeField] Transform firePoint;
    [SerializeField] BulletController bulletPrefabs;
    [SerializeField] BulletSpawner bulletSpawner;
    [SerializeField] HealthView healthView;

    private EnemyPool enemyPool;
    public int damage;

    public Team team => Team.Enemy;

    public void Initialize(EnemyPool enemyPool, Transform target)
    {
        this.enemyPool = enemyPool;
        this.target = target;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = new Health(50);

        healthView = GetComponent<HealthView>();

        movementModel = new MovementModel(3, transform);

        enemyAttack = new EnemyAttack(damage, 2f);

        bulletSpawner = new BulletSpawner(bulletPrefabs, team);

        health.OnDead += HandleEnemyDead;
    }

    // Update is called once per frame
    void Update()
    {
        enemyAttack.TimerCountdown(Time.deltaTime);

        EnemyMovement();

        if (CanAttack() && enemyAttack.canAttack)
        {
            TryAttack();
        }
    }

    void HandleEnemyDead()
    {
        GameEvents.OnEnemyKilled?.Invoke(10);

        enemyPool.ReturnToPool(this);
    }

    public void EnemyMovement()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        movementModel.Move(direction);
    }

    public void TryAttack()
    {
        if (!enemyAttack.canAttack) return;

        Shoot();

        enemyAttack.ConsumeAttack();
    }

    public void Shoot()
    {
        Vector2 direction = (target.position - firePoint.position).normalized;

        bulletSpawner.Spawn(firePoint.position, direction, team);
    }

    public bool CanAttack()
    {
        return Vector2.Distance(transform.position, target.position) < 5f;
    }

    public void TakeDamage(int amount)
    {
        health.Damage(amount);
        healthView.UpdateHealth(health.HP);
    }

    void ResetEnemy()
    {
        health = new Health(50);
    }
}
