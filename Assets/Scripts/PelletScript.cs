using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletScript : BulletScript
{
    public float spread = 2f;

    public new void Start()
    {
        base.Start();
        delta = new Vector3(
            Random.Range(-spread, spread),
            Random.Range(-spread, spread),
            1f
        );
    }
}
