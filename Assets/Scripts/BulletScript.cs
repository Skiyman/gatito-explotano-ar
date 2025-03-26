using System.Drawing;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    protected Vector3 delta = Vector3.forward;
    private float timer = 0f;
    public float lifetime = 3f;
    public float damage = 10f;

    public void Start()
    {
        if (GetComponent<Rigidbody>() == null)
        {
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        float progress = timer / lifetime;

        transform.Translate(new Vector3(
            delta.x * progress,
            delta.y * progress,
            delta.z
        ));

        if (timer >= lifetime)
        {
            // ураа суицид
            Destroy(gameObject);
        }
    }
}
