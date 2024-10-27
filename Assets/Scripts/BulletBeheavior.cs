using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBeheavior : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().loseHealth(damage);
            Destroy(gameObject);
        }
    }
}
