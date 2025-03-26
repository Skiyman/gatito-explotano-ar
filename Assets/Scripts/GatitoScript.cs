using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatitoScript : MonoBehaviour
{
    public GameObject explode;
    public float maxHealth = 100f;
    private float currentHealth;

    void Start () {
        currentHealth = maxHealth;
    }

    void Update()
    {
        Vector3 cameraPos = Camera.main.transform.position;
        transform.LookAt(cameraPos);
        transform.position = Vector3.MoveTowards(transform.position, cameraPos, 0.5f * Time.deltaTime);
    }

    void Die() {
        BoxCollider gatito = gameObject.GetComponent<BoxCollider>();
        Vector3 hitPoint = gatito.ClosestPoint(transform.position);
        Vector3 hitNormal = gatito.transform.forward;

        GameObject explodeInstance = Instantiate(explode, hitPoint, Quaternion.LookRotation(hitNormal));

        Destroy(explodeInstance, 0.8f);
        Destroy(gatito.gameObject);
    }

    public void TakeDamage(float damage) {
        currentHealth -= damage;

        if (currentHealth <= 0) {
            Die();
        }
    }

    void OnTriggerEnter(Collider bullet)
    {
        BulletScript bulletScript = bullet.GetComponent<BulletScript>();
        if (bullet != null) {
            TakeDamage(bulletScript.damage);
        }
        Destroy(bullet.gameObject);
    }
}
