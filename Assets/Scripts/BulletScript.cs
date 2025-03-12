using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject explode; // Пока просто дым

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
        transform.Translate(Vector3.forward * Time.deltaTime * 1.5f);
    }

    void OnTriggerEnter(Collider gatito)
    {
        Debug.Log("Пуля столкнулась с объектом: " + gatito.gameObject.name);

        Vector3 hitPoint = gatito.ClosestPoint(transform.position);
        Vector3 hitNormal = gatito.transform.forward;
        GameObject explodeInstance = Instantiate(explode, hitPoint, Quaternion.LookRotation(hitNormal));
        Destroy(gatito.gameObject);
        Destroy(this.gameObject);
        Destroy(explodeInstance, 0.8f);
    }
}
