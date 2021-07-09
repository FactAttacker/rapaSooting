using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
	// �ɼ� �г��� ������ �ٽ� ������ �簳�ϴ� �Լ�
    public void OnResume()
	{
		GameManager.instance.SetActiveOption(false);
	}

	// ������ �ٽ� �����ϵ��� �ϴ� �Լ�
	public void OnReStart()
	{
		SceneManager.LoadScene(0);
	}

	// ���� �����ϴ� �Լ�
	public void OnQuit()
	{
		Application.Quit();
	}
}
