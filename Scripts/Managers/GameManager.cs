using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameManager : Singleton<GameManager> {

	public void LoadGameScene(){
		SceneManager.LoadScene (1);
	}

	public void LoadMainScene(){
		SceneManager.LoadScene (0);
	}
}
