using UnityEngine;
using System.Collections;
using UnityEngine.UI;
 

[DisallowMultipleComponent]
public class Timer : MonoBehaviour
{
		
		public Text uiText;

		
		[HideInInspector]
		public int
				timeInSeconds;

		public Progress progress;

		
		private bool isRunning;

		private float timeCounter;

		
		private float sleepTime;


		void Awake ()
		{
				if (uiText == null) {
						uiText = GetComponent<Text> ();
				}
				
				Start ();
		}

		
		public void Start ()
		{
				if (!isRunning) {
						timeCounter = 0;
						sleepTime = 0.01f;
						isRunning = true;
						timeInSeconds = 0;
						InvokeRepeating("Wait",0,sleepTime);
				}
		}

	
		public void Stop ()
		{
				if (isRunning) {
						isRunning = false;
						CancelInvoke();
				}
		}

		
		public void Reset ()
		{
				Stop ();
				Start ();
		}

		
		private void Wait ()
		{
				timeCounter += sleepTime;
				timeInSeconds = (int)timeCounter;
				ApplyTime ();
				if (progress != null)
					progress.SetProgress (timeCounter);

		}

		private void ApplyTime ()
		{
				if (uiText == null) {
						return;
				}
			
				uiText.text = timeInSeconds.ToString ();
		}

		
		public static string GetNumberWithZeroFormat (int number)
		{
				string strNumber = "";
				if (number < 10) {
						strNumber += "0";
				}
				strNumber += number;
		
				return strNumber;
		}
}