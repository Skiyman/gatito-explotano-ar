using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatitoScript : MonoBehaviour
{
    public GameObject explode;

    void Update()
    {
        Vector3 cameraPos = Camera.main.transform.position;
        transform.LookAt(cameraPos);
        transform.position = Vector3.MoveTowards(transform.position, cameraPos, 0.5f * Time.deltaTime);
    }

    void OnTriggerEnter(Collider bullet)
    {
        BoxCollider gatito = gameObject.GetComponent<BoxCollider>();
        Vector3 hitPoint = gatito.ClosestPoint(transform.position);
        Vector3 hitNormal = gatito.transform.forward;

        GameObject explodeInstance = Instantiate(explode, hitPoint, Quaternion.LookRotation(hitNormal));

        Destroy(gatito.gameObject);
        Destroy(bullet.gameObject);
        Destroy(explodeInstance, 0.8f);
    }
}
