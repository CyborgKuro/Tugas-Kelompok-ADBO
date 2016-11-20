using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Kelas GameOver merepresentasikan game saat game over.
/// </summary>
public class GameOver : MonoBehaviour {

	/// <summary>
	/// High Score.
	/// </summary>
	private int highScore;

	/// <summary>
	/// Style GUI.
	/// </summary>
	public GUIStyle style2;

	/// <summary>
	/// Texture Retry.
	/// </summary>
	public Texture retry;

	/// <summary>
	/// Texture main menu.
	/// </summary>
	public Texture toMainMenu;
	public Camera cam;

	/// <summary>
	/// Method ini berfungsi untuk inisialisasi.
	/// </summary>
	void Start () {
		HighScoreScript.gameOver = false;
	}

	/// <summary>
	/// Mengatur kondisi game over setelah bertabrakan dengan Obstacle.
	/// </summary>
	/// <param name="collider">Collider.</param>
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.name == "Quad1") {
			Time.timeScale = 0;
			HighScoreScript.gameOver = true;
		}
	}

	/// <summary>
	/// Memunculkan pilihan setelah game over.
	/// </summary>
	void OnGUI(){
		if (HighScoreScript.gameOver) { 
			GUI.Label (new Rect (Screen.width * 0.3f, Screen.height * 0.45f, Screen.width * 0.75f, Screen.height * 0.25f), "GAME OVER!!!", style2);
			if (GUI.Button (new Rect (Screen.width * 0.48f, Screen.height * 0.55f, 50f, 50f), retry)) {
				SceneManager.LoadSceneAsync ("GameScene");
				Time.timeScale = 1;
			}
			if (GUI.Button (new Rect (Screen.width * 0.38f, Screen.height * 0.55f, 50f, 50f), toMainMenu)) {
				SceneManager.LoadSceneAsync ("MainMenuScene");
				Time.timeScale = 1;
			}
		}
	}
}
