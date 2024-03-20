using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    [HideInInspector] public WeopenManager weapon;
    public EnemyHealth EH;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            //Debug.Log(collision.gameObject.name);
            EnemyHealth enemyHealthh = collision.gameObject.GetComponentInChildren<EnemyHealth>();
            enemyHealthh.TakeDamage(weapon.damage);
            Destroy(this.gameObject);
            Debug.Log("Hit");
        }
    }
}
