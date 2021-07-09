using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Player�� �ִ� ��ġ�� ���ؼ� �̵��Ѵ�.
    public float speed = 5f;

    public GameObject targetPos;

    //0���̸� �������� 1���̸� �Ѿư���
    enum SelectionType
	{
        ����,
        ��������,
        �Ѿư���
	}
    SelectionType selectionType;
    int selection = 0;
    public int probability = 60;

    Vector3 dir;

    void Start()
    {
        PlayerFire playerFire = FindObjectOfType<PlayerFire>();
        // Ȯ���� ���� 1�� �Ǵ� 2���� ����� ����Ѵ�.
        if (playerFire != null && Random.Range(0, 100) > probability)
        {
            //selectionType = SelectionType.�Ѿư���;
            targetPos = playerFire.gameObject;
            dir = targetPos.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            //selectionType = SelectionType.��������;
            dir = Vector3.down;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // transform.position += speed * Time.deltaTime * Vector3.down;

        //Lerp
        // transform.position = Vector3.Lerp(transform.position, targetPos.transform.position, speed * Time.deltaTime);

        // position���� ����
        //transform.position += (targetPos.transform.position - transform.position) * (speed * Time.deltaTime);

        //����� Code
        transform.position += speed * Time.deltaTime * dir;
    }

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Player")
		{
            Destroy(col.gameObject);
            
            Destroy(gameObject);
        }
	}
}
