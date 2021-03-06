using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expand : MonoBehaviour {
	AudioSource audioExpand;

	private bool gazedAt;      
	private float Timer;
	private float gazeTime = 1.0f;
	void Start () {
		Timer = 0f;
		audioExpand = GetComponent<AudioSource>();

	}
	void Update () {
		if (gazedAt) {
			Timer += Time.deltaTime;
		}
		if (Timer>=gazeTime&&gazedAt) {
			Vector3 mov = Camera.main.transform.forward;
			mov.y = 0f;
			CameraOb.Cam.transform.position += mov * 0.06f;
		}
	}

	public void PointerEnter()
	{   
		gazedAt = true;
		iTween.ScaleTo(gameObject, iTween.Hash("x", 0.13, "y", 0.65, "easeType", "easeOutBack"));
        audioExpand.Play();
	}	

	public void PointerExit()   // 커서가 오브젝트를 벗어나면 크기를 원상  복구 한다.
	{
		gazedAt = false;
		Timer = 0f;
		iTween.ScaleTo(gameObject, iTween.Hash("x", 0.1, "y", 0.5, "easeType", "easeOutBack"));

	}
}
