using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
	[SerializeField] private AudioClip WinnerAudio;
	[SerializeField] private GameObject Winner;


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			SoundManager.instance.PlaySound(WinnerAudio);
			Winner.SetActive(true);
			Time.timeScale = 0;
		}
	}
}
