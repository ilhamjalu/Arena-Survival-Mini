using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable, ITeamMember
{
    [SerializeField] Health health;
    [SerializeField] MovementModel movementModel;
    [SerializeField] PlayerView playerView;
    [SerializeField] HealthView healthView;
    [SerializeField] BulletSpawner bulletSpawner;
    [SerializeField] BulletController bulletPrefabs;
    [SerializeField] WeaponView weaponView;

    public Team team => Team.Player;

    // Start is called before the first frame update
    void Start()
    {
        health = new Health(100);
        healthView = GetComponent<HealthView>();

        movementModel = new MovementModel(5, transform);

        playerView = GetComponent<PlayerView>();

        bulletSpawner = new BulletSpawner(bulletPrefabs, team);

        health.OnDead += HandlePlayerDead;
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
        ShootInput();
    }

    void HandlePlayerDead()
    {
        GameEvents.OnPlayerDead?.Invoke();
    }

    public void MovementInput()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        movementModel.Move(input);

        playerView.MovementVisual(input);
    }

    public void ShootInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryShootEnemy();
        }
    }

    private void TryShootEnemy()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider == null) return;

        EnemyController enemy = hit.collider.GetComponent<EnemyController>();

        if (enemy == null) return;

        Shoot(enemy.transform);
    }

    private void Shoot(Transform target)
    {
        Vector2 direction = (target.position - weaponView.firePoint.position).normalized;

        bulletSpawner.Spawn(weaponView.firePoint.position, direction, team);
        weaponView.UpdateDirection(direction);
    }

    public void TakeDamage(int amount)
    {
        health.Damage(amount);
        healthView.UpdateHealth(health.HP);
    }
}
