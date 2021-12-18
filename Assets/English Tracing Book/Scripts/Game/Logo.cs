using UnityEngine;
using System.Collections;
[DisallowMultipleComponent]
public class Logo : MonoBehaviour
{	public float sleepTime = 5;
	public string nextSceneName;
	void Start ()
	{
		Invoke ("LoadScene", sleepTime);
	}
	private void LoadScene ()
	{
		if (string.IsNullOrEmpty (nextSceneName)) {
			return;
		}
		Application.LoadLevel (nextSceneName);
	}
}
