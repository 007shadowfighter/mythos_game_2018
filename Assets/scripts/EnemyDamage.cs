using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(collision.gameObject);
        var hit = collision.gameObject;
        var health = hit.GetComponent<Health>();
        int damage = 20;

        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}
