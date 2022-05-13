using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public GameObject bulletEffect;
    public float explosionRadius = 0f;
    public int plusMoney = 20; 

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) { HitTarget(); return; }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World); transform.LookAt(target);
    }
    void HitTarget()
    { // добавляем эффект разрушения в место столкновения и удаляем все три объекта со сцены
        GameObject effectIns = (GameObject)Instantiate(bulletEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        Destroy(target.gameObject);
        Destroy(gameObject);
        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
        Stats.Money = Stats.Money + plusMoney;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}