using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Player가 있는 위치를 향해서 이동한다.
    public float speed = 5f;

    public GameObject targetPos;

    //0번이면 내려가기 1번이면 쫓아가기
    enum SelectionType
	{
        없음,
        내려가기,
        쫓아가기
	}
    SelectionType selectionType;
    int selection = 0;
    public int probability = 60;

    Vector3 dir;

    void Start()
    {
        PlayerFire playerFire = FindObjectOfType<PlayerFire>();
        // 확률에 따라 1번 또는 2번의 방식을 사용한다.
        if (playerFire != null && Random.Range(0, 100) > probability)
        {
            //selectionType = SelectionType.쫓아가기;
            targetPos = playerFire.gameObject;
            dir = targetPos.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            //selectionType = SelectionType.내려가기;
            dir = Vector3.down;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // transform.position += speed * Time.deltaTime * Vector3.down;

        //Lerp
        // transform.position = Vector3.Lerp(transform.position, targetPos.transform.position, speed * Time.deltaTime);

        // position으로 연산
        //transform.position += (targetPos.transform.position - transform.position) * (speed * Time.deltaTime);

        //강사님 Code
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
