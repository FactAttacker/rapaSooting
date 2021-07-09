using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAction : MonoBehaviour
{
    // 나는 생성되면 그냥 위쪽으로갈란다. 한없이
    public float speed = 1f;
    public float xAngle = 0f;
    public float yAngle = 0f;

    
    public GameObject ecplosionPrefab;
    

    void Start()
    {
        //Invoke(nameof(OnDestroyBullet), 1f);
    }

	void OnEnable()
	{
        Invoke(nameof(OnDestroyBullet), 1f);
    }

	void OnDestroyBullet()
	{
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
	
    void FixedUpdate()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision col)
    {
        // 부딪힌 대상이 Enemy라면 상대방을 제거하고, 나도 제거한다.
        //if (col.gameObject.name.Contains("Enemy"))
        if (col.gameObject.tag == "Enemy")
		{

            //폭발 이펙트 오브젝트를 생성한뒤 이펙트를 실행한다.
            GameObject go = Instantiate(ecplosionPrefab, col.transform.position, Quaternion.identity);
            ParticleSystem ps =  go.GetComponentInChildren<ParticleSystem>();
            ps.Play();

            //Ray cast 범위형 확인 Physics.OverlapSphere(transform.position,6.0f);
            /*
                Collider[] cols = Physics.OverlapSphere(transform.position,6.0f, 1 << 8); //8 layerMask 를 불러올수 있다. 2진법으로 시프트 연산자
			    foreach (Collider coll in cols)
			    {
                   Destroy(coll.gameObject);
                }
            */

            Destroy(col.gameObject);
            GameManager.instance.currentScore++;
            GameManager.instance.SetScoreText();
            Destroy(gameObject);
		}
	}
}
