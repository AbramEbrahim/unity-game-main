using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movePage : MonoBehaviour
{
    // Start is called before the first frame update
    public void Repeat()
    {
        Destroy(gameObject);
		SceneManager.LoadScene(1);
        Time.timeScale = 1;
	}
    public void MainView()
    {
		Destroy(gameObject);
		SceneManager.LoadScene(0);
	}
}
