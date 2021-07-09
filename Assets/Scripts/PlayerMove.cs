using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //사용자의 입력을 받아서 상하 또는 좌우로 이동하고 싶다.
    // 사용자 입력 : 좌우 화살표 키, 상하 화살표 키, AWSD 키
    // 이동 필요 요소 : 속도(방향, 속력) 시간
    public float moveSpeed = 0.1f;

    Rigidbody rb;
    void Start()
    {
        TryGetComponent(out rb);
    }

    void FixedUpdate()
    {
        /*if (Input.GetKeyDown(KeyCode.UpArrow))
		{
            print("나는 니가 위쪽 화살표 키를 누른것을 알고있다...");
		}*/

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(h, -v, 0);

        float distance = direction.magnitude; //벡터 길이를 동일하게 구해올 수 있다.
                                              // distance = new Vector3(direction.x / distance, direction.y / distance, direction.z / distance);

        //direction = direction.normalized;//해당 물체의 거리를 알기 위해 원래 거리를 확인하기위해 쓰는 변수(초기 값 확인 용도로 많이 쓰임) 
        direction.Normalize();

        //direction에 정해진 방향대로 이동하고 싶다.

        //p = p0 + vt
        float addSpeed = 1f;
        //좌측 Shift키를 누른 상태일때에는 속도가 2배로 증가한다.
        if (Input.GetKey(KeyCode.LeftShift))
        {
            addSpeed = 2f;
        }

        //transform.position += direction * moveSpeed * addSpeed * Time.deltaTime;
        //도착위치 (방향 * 속도) [transform.pointion은 월드 기준으로 나온다.]
        Vector3 arrivePos = (direction * moveSpeed * addSpeed * Time.deltaTime);

        //현재 위치에서 도착 지점까지 레이를 발사해 본다.
        Ray ray = new Ray(transform.position, direction);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, arrivePos.magnitude))
		{
            //hitInfo.point 레이를 맞은 거리까지
            transform.position = hitInfo.point;
            transform.position -= direction * 0.5f;//피봇위치가 가운데기 때문에 반은 부딪힌 충돌체에 반은 들어가게 되기때문에 어느방향에 부딪힌지 알기 때문에 그 충돌체의 반만 빼주면 (피봇이 중앙이기때문) 정확히 반만 된다.
        }
		else
		{
            rb.velocity = addSpeed * moveSpeed * direction ;
		}


        /*  
        print(Time.deltaTime);
        print(h);
        print(v);
        print(direction);*/

        //플레이어의 월드 좌표를 뷰포트 좌표로 환산한다.
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        /*print(viewPos);*/

        // 환산된 뷰포트 좌표를 0 ~ 1사이의 값을 제한한다.
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);

        //0,1로만 이뤄져있기 때문에 다시 월드 좌표로 구한다. (제한 적용 된 뷰포트를 월드 좌표로 변환해서 플레이어 포지션으로 덮어쓴다.)
        transform.position = Camera.main.ViewportToWorldPoint(viewPos);

    }
}
