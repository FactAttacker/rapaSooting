using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAction : MonoBehaviour
{
    PlayerFire pFire;

    // 나에게 부딪힌 대상을 제거한다.
    void Start()
    {
        pFire = FindObjectOfType<PlayerFire>();
    }

    //
    void Update()
    {
        
    }

	private void OnCollisionEnter(Collision collision)
	{
        /*if(!collision.gameObject.name.Contains("Player"))*/
        if(collision.gameObject.name.Contains("Bullet"))
		{
            collision.transform.TryGetComponent(out Rigidbody rb);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // 충돌한 대상을 제거한다.
            // Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
			//pFire.magazine.Add(collision.gameObject);
		}
		else if(collision.gameObject.tag == "Enemy")
		{
            Destroy(collision.gameObject);
        }
	}
}
