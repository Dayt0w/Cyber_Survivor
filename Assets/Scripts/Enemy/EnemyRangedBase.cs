using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRangedBase : EnemyBase
{
    // Start is called before the first frame update
    public GameObject projectile;
    void Start()
    {
        base.EnemyStart();
    }

    // Update is called once per frame
    void Update()
    {
        base.EnemyMoveUpdate();
        if(hittingPlayer){
            float timer = Time.realtimeSinceStartup - time;
            base.walking = false;
            if(timer >= attackSpeed){
                GameObject bullet = Instantiate(projectile);
                bullet.transform.position = transform.position;
                bullet.GetComponent<ProjectileScript>().targetLocation = base.player.transform;
                bullet.GetComponent<ProjectileScript>().damage = damage;
                GetCurrentTime();
            }
            
        } else{
            base.walking = true;
        }
    }
}
