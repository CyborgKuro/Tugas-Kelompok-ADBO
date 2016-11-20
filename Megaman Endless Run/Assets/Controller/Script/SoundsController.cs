using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Kelas Sounds controller mengontrol suara pada game.
/// </summary>
public class SoundsController : MonoBehaviour {
	
	/// <summary>
	/// Mengatur music yang dimainkan pada scene tertentu.
	/// </summary>
	void Awake(){
		GameObject[] gameBGM = GameObject.FindGameObjectsWithTag ("bgm");
		GameObject[] titleBGM = GameObject.FindGameObjectsWithTag ("music");
		if(SceneManager.GetActiveScene().name.Equals("GameScene")){
			for (int i = 0; i < titleBGM.Length; i++) {
				Destroy (titleBGM [i]);
			}
			if (gameBGM.Length > 1) {
				Destroy (this.gameObject);
			}
			DontDestroyOnLoad (this.gameObject);
		}
		else{
			for (int i = 0; i < gameBGM.Length; i++) {
				Destroy (gameBGM [i]);
			}
			if (titleBGM.Length > 1) {
				Destroy (this.gameObject);
			}
			if (!SceneManager.GetActiveScene ().name.Equals ("GameScene")) {
				DontDestroyOnLoad (this.gameObject);
			}
		}
	}
}
