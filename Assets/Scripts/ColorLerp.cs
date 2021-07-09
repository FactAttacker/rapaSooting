using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorLerp : MonoBehaviour
{
    Color colorAlpha0 = new Color();
    Color colorAlpha1 = new Color();

    public float speed = 1f;

    public float currentTime = 0f;

    public bool isFade = true;

    public GameObject box;
    public Image BG;
    public Text text;

    void Start()
    {
        // box.SetActive(true);
        colorAlpha0.a = 0f;
        colorAlpha1.a = 1f;
        Vector4 aa = new Color(0, 0, 0);
    }

    void Update()
    {
		/*
        if (box.activeInHierarchy)
		{
            if (isFade)
			{
                currentTime += Time.deltaTime * (1 / speed);

                colorAlpha0 = BG.color;
                colorAlpha1 = BG.color;
                colorAlpha0.a = 0f;
                colorAlpha1.a = 1f;
                Color color = Color.Lerp(colorAlpha0, colorAlpha1, currentTime);
                BG.color = color;

                color = Color.Lerp(colorAlpha0, colorAlpha1, currentTime);
                colorAlpha0 = text.color;
                colorAlpha1 = text.color;
                colorAlpha0.a = 0f;
                colorAlpha1.a = 1f;

                text.color = color;
                if (currentTime > 1f)  isFade = false;
            }
			else
			{
                currentTime -= Time.deltaTime * (1 / speed);

                colorAlpha0 = BG.color;
                colorAlpha1 = BG.color;
                colorAlpha0.a = 0f;
                colorAlpha1.a = 1f;
                Color color = Color.Lerp(colorAlpha0, colorAlpha1, currentTime);
                BG.color = color;


                colorAlpha0 = text.color;
                colorAlpha1 = text.color;
                colorAlpha0.a = 0f;
                colorAlpha1.a = 1f;
                color = Color.Lerp(colorAlpha0, colorAlpha1, currentTime);
                text.color = color;

                if (currentTime < 0f)
                {
                    isFade = false;
                    box.SetActive(false);
                }
            }
        }
        */
    }
}
