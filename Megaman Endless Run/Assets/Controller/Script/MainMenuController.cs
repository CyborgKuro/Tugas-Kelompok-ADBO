using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Kelas MainMenuController mengontrol MainMenuScene.
/// </summary>
public class MainMenuController : MonoBehaviour {

	/// <summary>
	/// Button - button yang ada di MainMenuScene.
	/// </summary>
	public Button StartGameButton, PreferenceButton, CreditButton, QuitButton;

	/// <summary>
	/// Method ini berfungsi untuk inisialisasi.
	/// </summary>
	void Start () {
		PlayerPrefs.SetString ("previousScene", "MainMenuScene");
		Button startGameBtn = StartGameButton.GetComponent<Button> ();
		Button prefBtn = PreferenceButton.GetComponent<Button>();
		Button creditBtn = CreditButton.GetComponent<Button> ();
		Button quitBtn = QuitButton.GetComponent<Button> ();
		startGameBtn.onClick.AddListener(startGameBtnOnClick);
		prefBtn.onClick.AddListener(prefBtnOnClick);
		creditBtn.onClick.AddListener(creditBtnOnClick);
		quitBtn.onClick.AddListener(quitBtnOnClick);
	}

	/// <summary>
	/// Mengatur tindakan yang dilakukan saat button StartGameButton diklik.
	/// Tindakan : Memulai game.
	/// </summary>
	public void startGameBtnOnClick(){
		SceneManager.LoadSceneAsync ("GameScene");
	}

	/// <summary>
	/// Mengatur tindakan yang dilakukan saat button PreferenceButton diklik.
	/// Tindakan : Memunculkan layar Preference.
	/// </summary>
	public void prefBtnOnClick(){
		SceneManager.LoadSceneAsync("PreferenceScene");
	}

	/// <summary>
	/// Mengatur tindakan yang dilakukan saat button CreditButton diklik.
	/// Tindakan : Memunculkan layar Credit.
	/// </summary>
	public void creditBtnOnClick(){
		SceneManager.LoadSceneAsync ("CreditScene");
	}

	/// <summary>
	/// Mengatur tindakan yang dilakukan saat button QuitButton diklik.
	/// Tindakan : Memunculkan layar Quit.
	/// </summary>
	public void quitBtnOnClick(){		
		SceneManager.LoadSceneAsync("QuitScene");
	}
}