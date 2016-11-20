using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Kelas CreditController mengontrol CreditScene.
/// </summary>
public class CreditController : MonoBehaviour {

	/// <summary>
	/// Button - button yang ada di CreditScene.
	/// </summary>
	public Button MainMenuButton;

	/// <summary>
	/// Method ini berfungsi untuk inisialisasi.
	/// </summary>
	void Start () {
		PlayerPrefs.SetString ("previousScene", "CreditScene");
		Button mainMenuBtn = MainMenuButton.GetComponent<Button> ();
		mainMenuBtn.onClick.AddListener(mainMenuBtnOnClick);
	}

	/// <summary>
	/// Mengatur tindakan yang dilakukan saat button StartGameButton diklik.
	/// Tindakan : Memulai game.
	/// </summary>
	public void mainMenuBtnOnClick(){
		SceneManager.LoadSceneAsync ("MainMenuScene");
	}
}
