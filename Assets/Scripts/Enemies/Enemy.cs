using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform aimOrigin;
    public Transform firingPoint;
    public Projectile projectilePrefab;
    public float attackDistance;
    public float shootDelay;
    public int earnedScore;

    private PlayerMovement player;
    private PlayerSegment segment;
    private bool canShoot;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        segment = GetComponent<PlayerSegment>();
        canShoot = true;
    }

    void Update()
    {
        if (CheckIfShouldShoot())
        {
            Shoot();
        }
    }

    protected bool CheckIfShouldShoot()
    {
        if (player != null)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < attackDistance)
            {
                Vector3 direction = (player.transform.position - transform.position).normalized;
                aimOrigin.transform.forward = direction;
                if (canShoot)
                {
                    return true;
                }
            }
        }

        return false;
    }

    protected virtual void Shoot()
    {
        Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
        StartCoroutine("DelayShoot");
    }

    IEnumerator DelayShoot ()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }

    public void OnDeath ()
    {
        segment.enabled = true;
        segment.Init();
        Destroy(this);
    }
}
