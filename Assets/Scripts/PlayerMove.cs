using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //������� �Է��� �޾Ƽ� ���� �Ǵ� �¿�� �̵��ϰ� �ʹ�.
    // ����� �Է� : �¿� ȭ��ǥ Ű, ���� ȭ��ǥ Ű, AWSD Ű
    // �̵� �ʿ� ��� : �ӵ�(����, �ӷ�) �ð�
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
            print("���� �ϰ� ���� ȭ��ǥ Ű�� �������� �˰��ִ�...");
		}*/

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(h, -v, 0);

        float distance = direction.magnitude; //���� ���̸� �����ϰ� ���ؿ� �� �ִ�.
                                              // distance = new Vector3(direction.x / distance, direction.y / distance, direction.z / distance);

        //direction = direction.normalized;//�ش� ��ü�� �Ÿ��� �˱� ���� ���� �Ÿ��� Ȯ���ϱ����� ���� ����(�ʱ� �� Ȯ�� �뵵�� ���� ����) 
        direction.Normalize();

        //direction�� ������ ������ �̵��ϰ� �ʹ�.

        //p = p0 + vt
        float addSpeed = 1f;
        //���� ShiftŰ�� ���� �����϶����� �ӵ��� 2��� �����Ѵ�.
        if (Input.GetKey(KeyCode.LeftShift))
        {
            addSpeed = 2f;
        }

        //transform.position += direction * moveSpeed * addSpeed * Time.deltaTime;
        //������ġ (���� * �ӵ�) [transform.pointion�� ���� �������� ���´�.]
        Vector3 arrivePos = (direction * moveSpeed * addSpeed * Time.deltaTime);

        //���� ��ġ���� ���� �������� ���̸� �߻��� ����.
        Ray ray = new Ray(transform.position, direction);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, arrivePos.magnitude))
		{
            //hitInfo.point ���̸� ���� �Ÿ�����
            transform.position = hitInfo.point;
            transform.position -= direction * 0.5f;//�Ǻ���ġ�� ����� ������ ���� �ε��� �浹ü�� ���� ���� �Ǳ⶧���� ������⿡ �ε����� �˱� ������ �� �浹ü�� �ݸ� ���ָ� (�Ǻ��� �߾��̱⶧��) ��Ȯ�� �ݸ� �ȴ�.
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

        //�÷��̾��� ���� ��ǥ�� ����Ʈ ��ǥ�� ȯ���Ѵ�.
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        /*print(viewPos);*/

        // ȯ��� ����Ʈ ��ǥ�� 0 ~ 1������ ���� �����Ѵ�.
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);

        //0,1�θ� �̷����ֱ� ������ �ٽ� ���� ��ǥ�� ���Ѵ�. (���� ���� �� ����Ʈ�� ���� ��ǥ�� ��ȯ�ؼ� �÷��̾� ���������� �����.)
        transform.position = Camera.main.ViewportToWorldPoint(viewPos);

    }
}
