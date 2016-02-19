using UnityEngine;
using UnityEngine.SceneManagement;

public class clickButtonPlay : MonoBehaviour {
	public void Play(){
		MySingleton.Instance.init ();
		SceneManager.LoadScene("GreenScene");﻿
	}
}