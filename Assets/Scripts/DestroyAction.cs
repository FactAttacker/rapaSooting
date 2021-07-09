using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAction : MonoBehaviour
{
    PlayerFire pFire;

    // ������ �ε��� ����� �����Ѵ�.
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

            // �浹�� ����� �����Ѵ�.
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
