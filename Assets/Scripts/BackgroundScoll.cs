using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScoll : MonoBehaviour
{
    // ���׸����� uv�� offset������ y���� ������Ų��.
    // Material, MeshRenderer, offset(Vector2), ��ũ�� �ӵ�

    public MeshRenderer mr;
    public float speed = 0.5f;
    Material mat;
    void Start()
    {
        //�޽� �������� 1�� ��Ƽ������ �����´�.
        mat = mr.material;
    }
   
    void Update()
    {
        //���͸��� uv offset ���� �����Ѵ�.
        mat.mainTextureOffset += speed * Time.deltaTime * Vector2.up;
    }
}
