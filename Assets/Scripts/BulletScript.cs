using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float damage = 1f;
    private Vector3 velocity;

    public void SetVelocity(Vector3 newVelocity) {
        velocity = newVelocity;
    }

    void Start()
    {
        if (GetComponent<Rigidbody>() == null)
        {
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true;
        }
    }

    void Update()
    {
        transform.Translate(velocity * Time.deltaTime * 7.5f);
    }
}
