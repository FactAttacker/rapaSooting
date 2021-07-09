using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 사용자 마우스 왼쪽 버튼을 클릭하면 총알 생성하고 싶다.
    public GameObject bulletFactory;
    public Transform bulletPoint;

    [Range(1,5)]
    public int bulletCount;

    public GameObject AudioBox;
    public AudioSource audio;

    // 총알을 담을 탄창 변수
    //public GameObject[] magazine = new GameObject[20];
    public List<GameObject> magazine = new List<GameObject>();
    public List<AudioSource> bulletSound = new List<AudioSource>();
    public int magazineSize = 20;
    public GameObject wareHouse;
    public Quaternion bulletRotation;
    void Start()
    {
        //탄창에 총알을 가득 채운다.
        for(int i = 0; i < magazineSize; i++)
		{
            // magazine[i] = Instantiate(bulletFactory);
            magazine.Add(Instantiate(bulletFactory));
            magazine[i].SetActive(false);
            //비활성화 된 총알들을 창고에 자식 오브젝트로 등록한다.
            magazine[i].transform.SetParent(wareHouse.transform, false);
            Instantiate(bulletFactory).TryGetComponent(out AudioSource audioSource);
            bulletSound.Add(audioSource);
            //bulletSound[i].transform.SetParent(AudioBox.transform, false);
         }
        bulletRotation = bulletFactory.transform.rotation; 
    }

	void OnDestroy()
	{
        GameManager.instance.SaveScore();
        GameManager.instance.OnGameOverUI();
    }



    bool isShatCoolTime = true;
    void Update()
    {
		/*if (Input.GetMouseButtonDown(0))
		{
            
		}*/
        /*
		if (Input.GetAxis("Fire1") == 1)
		{

		}*/

		if (isShatCoolTime && Input.GetButton("Fire1"))
		{
            isShatCoolTime = false;
            if (bulletFactory != null)
			{
                // MyFireSpcicalType();
                // FireSpecicalType1();
                // FireSpecicalType2();
                //FireNomarlType();
                FireListType();
                Invoke(nameof(OnShatCoolTime), 0.1f);
            }
		}
        if (Input.GetKeyDown(KeyCode.Q))
        {
            bulletCount = Mathf.Max(bulletCount - 1, 1);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            bulletCount = Mathf.Min(bulletCount + 1, 5);
        }
    }
    void OnShatCoolTime()
	{
        isShatCoolTime = true;
    }
    void FireNomarlType()
	{
        if(bulletFactory != null)
		{
            for(int i =0; i < magazine.Count; i++)
			{
                if (!magazine[i].activeSelf)
                {
                    magazine[i].SetActive(true);
                    magazine[i].transform.rotation = bulletRotation;
                    magazine[i].transform.position = transform.position;
                    break;
                }
            }
        }
	}

    void FireListType()
	{
      /*  if(magazine.Count > 0)
		{
            magazine[0].SetActive(true);
            magazine[0].transform.position = bulletPoint.position;
            
            //활성화된 총알은 리스트로부터 제거한다.
            magazine.RemoveAt(0);
        }*/

        if (bulletFactory != null && magazine.Count > 0)
        {
            for (int i = 0; i < magazine.Count; i++)
            {
                if (magazine[i] != null && !magazine[i].activeInHierarchy)
                {
                    magazine[i].SetActive(true);
                    magazine[i].transform.rotation = bulletRotation;
                    magazine[i].transform.position = transform.position;
                    //magazine.RemoveAt(i);
                    break;
                }
            }
           /* foreach(AudioSource sound in bulletSound)
			{
                if (!sound.isPlaying) {
                    sound.Play();
                    break;
                }

            }*/
        }
    }

    void MyFireSpcicalType()
	{
        GameObject go;
        for (int i = 0; i < bulletCount; i++)
        {
            go = Instantiate(bulletFactory);
            go.transform.position = new Vector3(bulletPoint.position.x + i - (bulletCount / 2) + (bulletCount % 2 == 0 ? 0.5f : 0f), bulletPoint.position.y, bulletPoint.position.z);
            go.TryGetComponent(out BulletAction bulletAction);
            bulletAction.yAngle = i + 1;
        }
        //Invoke(nameof(OnShatCoolTime), 0.1f);
    }

    public float between = 8.0f; //최대 간격
    void FireSpecicalType1()
    {
        //1. 엥커를 최대 범위의좌측(전체 범위 길이 / 2 [또는 * 0.5] )으로 잡는다.
        Vector3 anchor = new Vector3(between * -0.5f, 1.2f, 0);

        //2. 앵커위치로부터 이동 간격 = 전체 범위 / (총알 개수 + 1)
        float term = between / ((float)bulletCount + 1f);

        //3. 총알의 개수만큼 반복해서 앵커 위치에서 이동 간격만큼 떨어진 곳에 총알을 생성한다.
        GameObject go;
        for (int i = 0; i < bulletCount; i++)
		{
            go = Instantiate(bulletFactory);
            go.transform.position = transform.position + anchor + new Vector3(term * (i + 1), 0, 0);
		}
	}

    void FireSpecicalType2()
    {
        //1. 전체 범위의 길이를 정한다.
        float range = between * (bulletCount - 1);

        //2. 엥커를 최대 범위의좌측으로 잡는다.
        Vector3 anchor = new Vector3(range * -0.5f, 1.2f, 0);

        //3. 총알의 개수만큼 반복해서 앵커 위치에서 이동 간격만큼 떨어진 곳에 총알을 생성한다.
        GameObject go;
        for (int i = 0; i < bulletCount; i++)
		{
            go = Instantiate(bulletFactory);
            go.transform.position = transform.position + anchor + new Vector3(between * i, 0,0);
		}
        
    }
}
