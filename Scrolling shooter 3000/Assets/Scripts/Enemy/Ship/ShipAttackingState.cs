using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAttackingState : ShipState
{
    GameObject bulletSpawner;
    GameObject bullet;

    ShipController _ship;

    public static Action onEnemyShipAttack;

    float timeBetweenAttacks = 0.2f;

    public override void EnterState(ShipController ship)
    {
        _ship = ship;
        bulletSpawner = ship.bulletSpawner;
        StartCoroutine(Attack());
    }

    public override void ExitState(ShipController ship)
    {
    }

    public override void UpdateState(ShipController ship)
    {
    } 

    IEnumerator Attack()
    {
        int attacksDone = 0;
        while(attacksDone <= 2)
        {
            bullet = EnemyBulletPool.Instance.GetPooledObjects();

            if(bullet != null)
            {
                bullet.transform.position = bulletSpawner.transform.position;
                bullet.SetActive(true);
            }
            onEnemyShipAttack?.Invoke();
            attacksDone++;
            yield return new WaitForSeconds(timeBetweenAttacks);
        }
        _ship.ChangeState(_ship.idle);
    }
}
