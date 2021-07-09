using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMySelf : MonoBehaviour
{
    public float delayTime = 1f;
    public float currentTime = 0f;
/*    void Start()
    {
        void ThisDestory()
		{
            Destroy(gameObject);
		}
        Invoke(nameof(ThisDestory), delayTime);
    }*/

	void Update()
	{
        currentTime += Time.deltaTime;

        if (currentTime >= delayTime)
		{
            Destroy(gameObject);
        }
	}
}
