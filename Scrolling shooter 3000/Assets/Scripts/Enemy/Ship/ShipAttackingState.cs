using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAttackingState : ShipState
{
    GameObject bulletSpawner;
    GameObject bullet;

    ShipController _ship;

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
            attacksDone++;
            yield return new WaitForSeconds(0.5f);
        }
        _ship.ChangeState(_ship.idle);
    }
}
