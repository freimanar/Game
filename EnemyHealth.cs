using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public static int enemyhealth = 10;
	void Update()
    {
        
    }
	public void Death()
	{
		if (enemyhealth == 0)
		{
			Destroy(gameObject);
		}
	}
	private void OnColliderEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Bullet")
		{
			enemyhealth -= 5;
		}
	}
}
