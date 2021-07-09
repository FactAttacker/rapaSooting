using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScoll : MonoBehaviour
{
    // 머테리얼의 uv의 offset값에서 y축을 증가시킨다.
    // Material, MeshRenderer, offset(Vector2), 스크롤 속도

    public MeshRenderer mr;
    public float speed = 0.5f;
    Material mat;
    void Start()
    {
        //메쉬 렌더러의 1번 머티리얼을 가져온다.
        mat = mr.material;
    }
   
    void Update()
    {
        //머터리얼 uv offset 값을 변경한다.
        mat.mainTextureOffset += speed * Time.deltaTime * Vector2.up;
    }
}
