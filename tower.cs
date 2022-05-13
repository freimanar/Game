using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{
    private Transform target;
    public float range = 15f; // радиус атаки пушки
    public string enemyTag = "Enemy"; // тэг для атаки
    public Transform partToRotate; //объект поворота
    public float turnSpeed = 10f; // скорость поворота башни
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public GameObject bulletprefab; // объект пули
    public Transform firePoint; // объект из которого будет вылетать пуля


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); // определяем тэг для нашего противника
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
            return;
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        { 
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    { 
        GameObject bulletGo = (GameObject)Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

