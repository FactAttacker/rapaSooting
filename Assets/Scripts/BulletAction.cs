using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAction : MonoBehaviour
{
    // ���� �����Ǹ� �׳� �������ΰ�����. �Ѿ���
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
        // �ε��� ����� Enemy��� ������ �����ϰ�, ���� �����Ѵ�.
        //if (col.gameObject.name.Contains("Enemy"))
        if (col.gameObject.tag == "Enemy")
		{

            //���� ����Ʈ ������Ʈ�� �����ѵ� ����Ʈ�� �����Ѵ�.
            GameObject go = Instantiate(ecplosionPrefab, col.transform.position, Quaternion.identity);
            ParticleSystem ps =  go.GetComponentInChildren<ParticleSystem>();
            ps.Play();

            //Ray cast ������ Ȯ�� Physics.OverlapSphere(transform.position,6.0f);
            /*
                Collider[] cols = Physics.OverlapSphere(transform.position,6.0f, 1 << 8); //8 layerMask �� �ҷ��ü� �ִ�. 2�������� ����Ʈ ������
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
