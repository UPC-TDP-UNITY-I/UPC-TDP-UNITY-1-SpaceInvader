using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManagment : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GameObject.Find ("GOP_ButtonLobby").GetComponent<ButtonComponent> ().OnClick(this.OnClickHandler);
	}

	private void OnClickHandler() {
		SceneManager.LoadScene ("Scene_Lobby");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
