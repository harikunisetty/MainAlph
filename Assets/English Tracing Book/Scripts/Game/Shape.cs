using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Shape : MonoBehaviour
{
	
	public List<EnglishTracingBook.Path> paths = new List<EnglishTracingBook.Path> ();
	public AudioClip clip;
	[Range (0, 500)]
	public int threeStarsTimePeriod = 10;	
	[Range (0, 500)]
	public int twoStarsTimePeriod = 20;
	[HideInInspector]
	public bool completed;

	[HideInInspector]
	public bool enablePriorityOrder=true;
	void Start ()
	{
		if (GameManager.compoundShape == null) {
			if (paths.Count != 0) {
				Invoke ("EnableTracingHand", 0.2f);
				ShowPathNumbers (0);
			}
		}
	}

	public void Spell ()
	{
		if (clip == null) {
			return;
		}

		AudioSources.instance.audioSources [1].Stop ();
		AudioSources.instance.audioSources [1].clip = clip;
		AudioSources.instance.audioSources [1].Play ();
	}
	public void ShowPathNumbers (int index)
	{
		for (int i = 0; i < paths.Count; i++) {
			if (i != index) {
				paths [i].SetNumbersStatus (false);
			} else {
				paths [i].SetNumbersStatus (true);
			}
		}
	}
	public int GetCurrentPathIndex ()
	{
		int index = -1;
		for (int i = 0; i < paths.Count; i++) {

			if (paths [i].completed) {
				continue;
			}

			bool isCurrentPath = true;
			for (int j = 0; j < i; j++) {
				if (!paths [j].completed) {
					isCurrentPath = false;
					break;
				}
			}

			if (isCurrentPath) {
				index = i;
				break;
			}
		}

		return index;
	}
	public bool IsCurrentPath (EnglishTracingBook.Path path)
	{
		bool isCurrentPath = false;

		if (!enablePriorityOrder) {
			return true;
		}

		if (path == null) {
			return isCurrentPath;
		}

		isCurrentPath = true;
		for (int i = 0; i < paths.Count; i++) {
			if (paths [i].GetInstanceID () == path.GetInstanceID ()) {
				for (int j = 0; j < i; j++) {
					if (!paths [j].completed) {
						isCurrentPath = false;
						break;
					}
				}
				break;
			}
		}

		return isCurrentPath;
	}
	public void EnableTracingHand ()
	{
		int currentPathIndex = GetCurrentPathIndex ();
		if (currentPathIndex == -1) {
			return;
		}
		Animator animator = GetComponent<Animator> ();
		animator.SetTrigger (name);
		animator.SetTrigger (paths [currentPathIndex].name.Replace ("Path", name.Split ('-') [0]));
	}
	public void DisableTracingHand ()
	{
		int currentPathIndex = GetCurrentPathIndex ();
		if (currentPathIndex == -1) {
			return;
		}
		Animator animator = GetComponent<Animator> ();
		//animator.SetBool (name,false);
		animator.SetBool (paths [currentPathIndex].name.Replace ("Path", name.Split ('-') [0]), false);
	}
	public string GetTitle ()
	{
		if (GameManager.compoundShape == null) {
			return name.Split ('-') [0];
		}
		return GameManager.compoundShape.name.Split ('-') [0];
	}
}
