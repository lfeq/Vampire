using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float cooldown;

    private PlayerController playerController;
    private float nextShootTime;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        Shoot();
    }

    private void Update() {
        nextShootTime -= Time.deltaTime;
        if (nextShootTime <= 0) {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject tempBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        BulletMovement tempBulletMovement = tempBullet.GetComponent<BulletMovement>();
        SetBulletDirection(tempBulletMovement);
        nextShootTime = cooldown;
    }

    private void SetBulletDirection(BulletMovement bulletMovement)
    {
        switch (playerController.playerDirection)
        {
            case PlayerDirection.North:
                bulletMovement.SetDirection(new Vector2(0, 1));
                break;
            case PlayerDirection.South:
                bulletMovement.SetDirection(new Vector2(0, -1));
                break;
            case PlayerDirection.East:
                bulletMovement.SetDirection(new Vector2(1, 0));
                break;
            case PlayerDirection.West:
                bulletMovement.SetDirection(new Vector2(-1, 0));
                break;
        }
    }
}
