using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("General")]

    public float range = 15f;
    private Transform target;
    private Enemy targetEnemy;

    [Header("Use bullets (default)")]

    public GameObject bulletPrefab;

    public float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Use laser")]

    public bool useLaser;
    public int damageOverTime = 30;
    public float slowAmount = 0.5f;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    [Header("Unity setup fields")]

    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public Animator animator;
    private float turnSpeed = 5f;
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);   
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = target.GetComponent<Enemy>();
            if(animator != null)
            {
                animator.SetBool("IsIdle", false);
            }
        }
        else
        {
            target = null;
            if (animator != null)
            {
                animator.SetBool("IsIdle", true);
            }
        }
    }

    void Update()
    {
        if(target == null)
        {
            if (useLaser && lineRenderer.enabled == true)
            {
                lineRenderer.enabled = false;
                impactEffect.Stop();
                impactLight.enabled = false;
                animator.SetBool("IsIdle", true);
            }
            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
            return;
        }

        if(fireCountDown <= 0)
        {
            if(animator != null)
            {
                animator.SetTrigger("Shoot");
            }
            else
            {
                Shoot();
            }
            fireCountDown = 1 / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Shoot()
    {
        GameObject bulletGO =  (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void Laser()
    {
        targetEnemy.takeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowAmount);

        if (lineRenderer.enabled == false)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
            animator.SetBool("IsIdle", false);
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);

        impactEffect.transform.position = target.position + dir.normalized * 1.5f;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
