using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Kelas QuitController mengontrol QuitScene.
/// </summary>
public class QuitController : MonoBehaviour {

	/// <summary>
	/// Button - button yang ada di QuitScene.
	/// </summary>
	public Button YesButton, NoButton;

	/// <summary>
	/// Atribut yang menyimpan nama scene sebelumnya.
	/// </summary>
	private string previousLevel;

	/// <summary>
	/// Method ini berfungsi untuk inisialisasi.
	/// </summary>
	void Start () {
		previousLevel = PlayerPrefs.GetString ("previousScene");
		Button yesBtn = YesButton.GetComponent<Button> ();
		Button noBtn = NoButton.GetComponent<Button>();
		yesBtn.onClick.AddListener(yesBtnOnClick);
		noBtn.onClick.AddListener(noBtnOnClick);
	}

	/// <summary>
	/// Mengatur tindakan yang dilakukan saat button YesButton diklik.
	/// Tindakan : Keluar dari game.
	/// </summary>
	public void yesBtnOnClick(){
		Application.Quit ();
	}

	/// <summary>
	/// Mengatur tindakan yang dilakukan saat button NoButton diklik.
	/// Tindakan : Kembali ke layar sebelumnya.
	/// </summary>
	public void noBtnOnClick(){
		PlayerPrefs.SetString ("previousScene", "QuitScene");
		SceneManager.LoadSceneAsync(previousLevel);
	}
}
