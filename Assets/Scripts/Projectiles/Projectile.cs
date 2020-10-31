using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float initialForce;
    private Rigidbody rigidbody;
    public int damage;
    private void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * initialForce);
        Destroy(gameObject,10);
    }
}
