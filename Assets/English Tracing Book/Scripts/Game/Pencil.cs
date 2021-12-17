using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class Pencil : MonoBehaviour
{
	
	public Color value;
	void Start(){
		GetComponent<Button> ().onClick.AddListener (() => GameObject.FindObjectOfType<UIEvents> ().PencilClickEvent (this));
	}
	public void EnableSelection(){
		GetComponent<Animator>().SetBool("RunScale",true);
	}
	public void DisableSelection(){
		GetComponent<Animator>().SetBool("RunScale",false);
	}
}
