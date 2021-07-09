using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForLotto : MonoBehaviour
{
    string log = "";
    List<int> lottoList = new List<int>();
    void Update()
    {
        
		if (Input.GetMouseButtonDown(0))
		{
            log = "";
            lottoList.Clear();
            for (int i = 0; i < 6; i++)
            {
                int num = Random.Range(1, 46);//10
                if (lottoList.Contains(num)) --i;
                else
                {
                    lottoList.Add(num);
                    log +=  lottoList[i].ToString() + (i != 5 ? "/" : "");
                }
            }
           // Debug.Log(log);
		}
       
    }

}
