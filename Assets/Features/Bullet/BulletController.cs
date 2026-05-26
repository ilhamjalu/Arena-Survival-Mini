using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] BulletData bulletData;
    [SerializeField] MovementModel movementModel;

    private Vector2 direction;
    private Team ownerTeam;

    public void Initialize(Vector2 direction, Team ownerTeam)
    {
        this.direction = direction;
        this.ownerTeam = ownerTeam;
    }

    // Start is called before the first frame update
    void Start()
    {
        bulletData = new BulletData(5, 20);
        movementModel = new MovementModel(bulletData.bulletSpeed, transform);
    }

    // Update is called once per frame
    void Update()
    {
        BulletMovement();
    }

    public void BulletMovement()
    {
        movementModel.Move(direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<ITeamMember>(out var teamMember))
        {
            if (teamMember.team == ownerTeam) return;
        }

        if (collision.gameObject.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(bulletData.bulletDamage);

            Destroy(gameObject);
        }
    }
}
