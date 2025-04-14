using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnPosition;
    public float projectileForce = 500f;
  
    protected override void Attack()
    {
        base.Attack();
        GameObject go = Instantiate(projectilePrefab, projectileSpawnPosition.position, projectileSpawnPosition.rotation);

        go.GetComponent<Rigidbody>().AddForce(go.transform.forward * projectileForce);
    }

    protected override void Update()
    {
        this.transform.LookAt(player.transform.position);


        base.Update();
    }

}
