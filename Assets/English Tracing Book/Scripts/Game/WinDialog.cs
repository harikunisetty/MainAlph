using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class WinDialog : MonoBehaviour
{
		
		private StarsNumber starsNumber;
		public AudioClip starSoundEffect;
		public Animator WinDialogAnimator;
		public Animator firstStarFading;
		public Animator secondStarFading;
		public Animator thirdStarFading;
		public Text levelTitle;
		public Timer timer;
		private AudioSource effectsAudioSource;

		void Start ()
		{
				///Setting up the references
				if (WinDialogAnimator == null) 
				{
						WinDialogAnimator = GetComponent<Animator> ();
				}

				if (firstStarFading == null) 
				{
						firstStarFading = transform.Find ("Stars").Find ("FirstStarFading").GetComponent<Animator> ();
				}

				if (secondStarFading == null) 
				{
						secondStarFading = transform.Find ("Stars").Find ("SecondStarFading").GetComponent<Animator> ();
				}

				if (thirdStarFading == null) 
				{
						thirdStarFading = transform.Find ("Stars").Find ("ThirdStarFading").GetComponent<Animator> ();
				}

				if (effectsAudioSource == null) 
				{
						effectsAudioSource = GameObject.Find ("AudioSources").GetComponents<AudioSource> () [1];
				}
				
				if (levelTitle == null) 
		        {
						levelTitle = transform.Find ("Level").GetComponent<Text> ();
				}

				if (timer == null)
				{
						timer = GameObject.Find ("Time").GetComponent<Timer> ();
				}
		}
		void OnEnable ()
		{
				Hide ();
		}
		public void Show ()
		{
				if (WinDialogAnimator == null) {
						return;
				}
				WinDialogAnimator.SetTrigger ("Running");
		}
		public void Hide ()
		{
				StopAllCoroutines ();
				WinDialogAnimator.SetBool ("Running", false);
				firstStarFading.SetBool ("Running", false);
			/*	firstStarFading.transform.Find ("Effect").GetComponent<ParticleEmitter> ().emit = false;*/
				secondStarFading.SetBool ("Running", false);
				/*secondStarFading.transform.Find ("Effect").GetComponent<ParticleEmitter> ().emit = false;
				thirdStarFading.SetBool ("Running", false);*/
				/*thirdStarFading.transform.Find ("Effect").GetComponent<ParticleEmitter> ().emit = false;*/
		}
		public IEnumerator FadeStars ()
		{
				starsNumber = timer.progress.starsNumber;
				float delayBetweenStars = 0.5f;
				if (starsNumber == StarsNumber.ONE) {//Fade with One Star
						if (effectsAudioSource != null)
								CommonUtil.PlayOneShotClipAt (starSoundEffect, Vector3.zero, effectsAudioSource.volume);
						firstStarFading.SetTrigger ("Running");
						ShowEffect (firstStarFading.transform);
				} else if (starsNumber == StarsNumber.TWO) {//Fade with Two Stars
						if (effectsAudioSource != null)
								CommonUtil.PlayOneShotClipAt (starSoundEffect, Vector3.zero, effectsAudioSource.volume);
						firstStarFading.SetTrigger ("Running");
						ShowEffect (firstStarFading.transform);
						yield return new WaitForSeconds (delayBetweenStars);
						if (effectsAudioSource != null)
								CommonUtil.PlayOneShotClipAt (starSoundEffect, Vector3.zero, effectsAudioSource.volume);
						secondStarFading.SetTrigger ("Running");
						ShowEffect (secondStarFading.transform);
				} else if (starsNumber == StarsNumber.THREE) {//Fade with Three Stars
						if (effectsAudioSource != null)
								CommonUtil.PlayOneShotClipAt (starSoundEffect, Vector3.zero, effectsAudioSource.volume);
						firstStarFading.SetTrigger ("Running");
						ShowEffect (firstStarFading.transform);
						yield return new WaitForSeconds (delayBetweenStars);
						if (effectsAudioSource != null)
								CommonUtil.PlayOneShotClipAt (starSoundEffect, Vector3.zero, effectsAudioSource.volume);
						secondStarFading.SetTrigger ("Running");
						ShowEffect (secondStarFading.transform);
						yield return new WaitForSeconds (delayBetweenStars);
						if (effectsAudioSource != null)
								CommonUtil.PlayOneShotClipAt (starSoundEffect, Vector3.zero, effectsAudioSource.volume);
						thirdStarFading.SetTrigger ("Running");
						ShowEffect (thirdStarFading.transform);

				}
				yield return 0;
		}

		private void ShowEffect (Transform fadingStar)
		{
				if (fadingStar == null) {
						return;
				}
				StartCoroutine (ShowEffectCouroutine (fadingStar));
		}
		private IEnumerator ShowEffectCouroutine (Transform fadingStar)
		{
				yield return new WaitForSeconds (0.5f);
				/*fadingStar.Find ("Effect").GetComponent<ParticleEmitter> ().emit = true;*/
		}
		public void SetLevelTitle (string value)
		{
				if (string.IsNullOrEmpty (value) || levelTitle == null) {
						return;
				}
				levelTitle.text = value;
		}

		public enum StarsNumber
		{
				ONE,
				TWO,
				THREE
		}
}