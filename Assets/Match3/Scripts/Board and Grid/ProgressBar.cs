using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour
{


	public int sceneID;
	public Image LoadingImg;
	public Text progressText;


	void Start()
	{

		StartCoroutine(AsyncLoad());

	}

	IEnumerator AsyncLoad()
	{

		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
		while (!operation.isDone)
		{

			float progress = operation.progress / 0.9f;
			LoadingImg.fillAmount = progress;
			progressText.text = string.Format("{0:0}%", progress * 100);
			yield return null;

		}
	}

}
