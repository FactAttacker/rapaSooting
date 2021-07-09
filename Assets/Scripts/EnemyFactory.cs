using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    // ������ �ð����� Enemy�� �����ϰ� �ʹ�.
    public GameObject enemySource;
    public float delayTime = 2.0f;

    float crurrentTime = 0f;

    void Start()
	{
		delayTime = Random.Range(0.5f, delayTime);
        Invoke(nameof(Destroy), 2f);
	}

    void EnemyDestroy()
	{
        Destroy(gameObject);
	}

	void Update()
    {
        // 1. ���� �ð��� üũ�ؼ� ������ �ð��� �Ǿ����� Ȯ���Ѵ�.

        // 1-1. ���� ��ġ�� ������ ��ġ�� Enemy�� �����Ѵ�.
        // 1-2. ���� �ð��� 0���� �ʱ�ȭ �Ѵ�.

        // 2. ���� ���ο����κ��� ���� �����ӱ��� �ɸ� �ð��� ���� �ð� ������ �����Ѵ�. 

        crurrentTime += Time.deltaTime;
        if (crurrentTime >= delayTime)
        {
            GameObject enemy = Instantiate(enemySource, transform.position, Quaternion.identity);
            crurrentTime = 0f;
        }
    }
}
