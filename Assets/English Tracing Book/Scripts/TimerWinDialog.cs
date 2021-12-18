using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerWinDialog : MonoBehaviour
{
	[HideInInspector]
	public int
				   timeInSeconds;

	


	private bool isRunning;

	private float timeCounter;


	private float sleepTime;


	void Awake()
	{
		Start();
	}


	public void Start()
	{
		if (!isRunning)
		{
			timeCounter = 0;
			sleepTime = 0.01f;
			isRunning = true;
			timeInSeconds = 10;
			InvokeRepeating("Wait", 0, sleepTime);
		}
	}


	public void Stop()
	{
		if (isRunning)
		{
			isRunning = false;
			CancelInvoke();
		}
	}
}
