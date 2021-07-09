using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject canvasUI;
    public Text[] scoreText = new Text[2];
    public int currentScore = 0;
    public int bastScore = 0;


    [System.Serializable]
    class GameOverObj
	{
        public GameObject gameOverUI;
        public GameObject bg;
        public Text text;
	}
    [SerializeField]
    GameOverObj gameOverObj;

    public float fadeSpeed = 0.5f;
    WaitForSeconds waitSpeed;
    private void Awake()
	{
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    Color bgColor;
	void Start()
    {
        waitSpeed = new WaitForSeconds(fadeSpeed);
        SetActiveOption(false);
        SetScoreText();
        bastScore = PlayerPrefs.GetInt("Score");
        LoadScore();


        bgColor =  gameOverObj.bg.GetComponent<Image>().color;
        
        bgChangeColor.a = 0f;
        bgColor = bgChangeColor;
    }

    Color bgChangeColor = new Color();
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
            SetActiveOption(!canvasUI.activeSelf);
        }
    }
    //현재 점수를 UI에 반영한다.
    public void SetScoreText()
	{
        scoreText[0].text = "현재 점수 :" + currentScore.ToString();
       
    }
    public void SaveScore()
	{
        if (currentScore > bastScore) bastScore = currentScore;
        PlayerPrefs.SetInt("Score", bastScore);
        print("저장 완료 됐습니다.");

        LoadScore();
    }
    public void LoadScore()
	{
        scoreText[1].text = "최고 점수 :" + PlayerPrefs.GetInt("Score").ToString();
    }


    //옵성창을 나타내는 함수
    public void SetActiveOption(bool toggle)
	{
        // UI창을 활성/비활성 화
        if(canvasUI != null) canvasUI.SetActive(toggle);
        //오브젝트 시간을 흐름을 멈춘다.
        if (toggle)
		{
            Time.timeScale = 0;
		}
		else
		{
            Time.timeScale = 1;
        }
    }
    public void OnGameOverUI()
	{
        StartCoroutine(GameOverCoroutine());
    }
    IEnumerator GameOverCoroutine()
	{
        Image bg = gameOverObj.bg.GetComponent<Image>();
        Text text = gameOverObj.text.GetComponent<Text>();
		// gameOverObj.bg;

		Color colorBG = bg.color;
		Color colorText = text.color;

		colorBG.a = 0f;
        colorText.a = 0f;

        bg.color = colorBG;
        text.color = colorText;

        gameOverObj.gameOverUI.SetActive(true);

        while (bg.color.a <  1f)
        {
            colorBG.a += Time.deltaTime / fadeSpeed; 
            colorText.a += Time.deltaTime / fadeSpeed;
            bg.color = colorBG;
            text.color = colorText;

            if (bg.color.a >= 1f) colorBG.a = 1f;
            if (text.color.a >= 1f) colorText.a = 1f;

            yield return waitSpeed;
        }

        bg.color = colorBG;
        text.color = colorText;

        while (bg.color.a > 0f)
        {
            colorBG.a -= Time.deltaTime / fadeSpeed;
            colorText.a -= Time.deltaTime / fadeSpeed;
            bg.color = colorBG;
            text.color = colorText;

            if (bg.color.a <= 0f) colorBG.a = 0f;
            if (text.color.a <= 0f) colorText.a = 0f;
            yield return waitSpeed;
        }
        bg.color = colorBG;
        text.color = colorText;

        gameOverObj.gameOverUI.SetActive(false);
        SetActiveOption(true);

    }

}
