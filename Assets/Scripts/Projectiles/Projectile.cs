using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float initialForce;
    public int damage;
    public float timeTillDestroy;

    private Rigidbody rigidbody;
    
    private void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * initialForce);
        Destroy(gameObject, timeTillDestroy);
    }
}
