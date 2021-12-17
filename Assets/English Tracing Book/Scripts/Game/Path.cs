using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


namespace EnglishTracingBook
{
	public class Path : MonoBehaviour
	{
		public bool flip;

		[HideInInspector]
		public bool completed;
		public FillMethod fillMethod;
		public ShapeType type = ShapeType.Vertical;
		public float offset = 90;
		public float completeOffset = 0.85f;
		public Transform firstNumber;
		public Transform secondNumber;
		private bool autoFill;
		public bool quarterRestriction = true;
		public float radialAngleOffset = 0;
		[HideInInspector]
		public Shape shape;

		public void Awake ()
		{
			shape = GetComponentInParent<Shape> ();
		}

		
		public void AutoFill ()
		{
			StartCoroutine ("AutoFillCoroutine");
		}
		public void SetNumbersStatus (bool status)
		{
			Color tempColor = Color.white;
			List<Transform> numbers = CommonUtil.FindChildrenByTag (transform.Find ("Numbers"), "Number");
			foreach (Transform number in numbers) {
				if (number == null)
					continue;

				if (status) {
					EnableStartCollider ();
					number.GetComponent<Animator> ().SetBool ("Select", true);
					tempColor.a = 1;
				} else {

					if (shape.enablePriorityOrder || completed) {
						DisableStartCollider ();
					}

					if (shape.enablePriorityOrder) {
						number.GetComponent<Animator> ().SetBool ("Select", false);
						tempColor.a = 0.3f;
					}
				}

				number.GetComponent<Image> ().color = tempColor;
			}
		}

		public void SetNumbersVisibility (bool visible)
		{
			List<Transform> numbers = CommonUtil.FindChildrenByTag (transform.Find ("Numbers").transform, "Number");
			foreach (Transform number in numbers) {
				if (number != null)
					number.gameObject.SetActive (visible);
			}
		}

		public void EnableStartCollider ()
		{
			transform.Find ("Start").GetComponent<Collider2D> ().enabled = true;
		}
		public void DisableStartCollider ()
		{
			transform.Find ("Start").GetComponent<Collider2D> ().enabled = false;
		}

		public void Reset ()
		{
			SetNumbersVisibility (true);
			completed = false;
			if (!shape.enablePriorityOrder) {
				SetNumbersStatus (true);
			}
			StartCoroutine ("ReleaseCoroutine");
		}
		private IEnumerator AutoFillCoroutine ()
		{
			Image image = CommonUtil.FindChildByTag (transform, "Fill").GetComponent<Image> ();
			while (image.fillAmount < 1) {
				image.fillAmount += 0.02f;
				yield return new WaitForSeconds (0.001f);
			}
		}

		private IEnumerator ReleaseCoroutine ()
		{
			Image image = CommonUtil.FindChildByTag (transform, "Fill").GetComponent<Image> ();
			while (image.fillAmount > 0) {
				image.fillAmount -= 0.02f;
				yield return new WaitForSeconds (0.005f);
			}
		}

		public enum ShapeType
		{

			Horizontal,
			Vertical
		}

		public enum FillMethod
		{
			Radial,
			Linear,
			Point
		}

		public enum CenterReference
		{
			PATH_GAMEOBJECT,
			FILL_GAMEOBJECT
		}
	}
}