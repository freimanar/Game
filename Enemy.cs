using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

	public float speed = 10f;
	private Transform target;
	private int wavepointIndex = 0;
	public static int Health = 100;
	public int damage = 10;

	void Start()
	{
		target = Weapoints.points[0];
	}

	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
		if (Vector3.Distance(transform.position, target.position) <= 0.3f) { GetNextWaypoint(); }
		Vector3 relativePos = target.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
		transform.rotation = rotation;
	}
	void GetNextWaypoint()
	{
		if (wavepointIndex >= Weapoints.points.Length - 1)
		{
			Destroy(gameObject);
			Health = Health - damage; // отнимаем деньги при достижении конечной точки
			return;
		}
		wavepointIndex++;
		target = Weapoints.points[wavepointIndex];
	}
}