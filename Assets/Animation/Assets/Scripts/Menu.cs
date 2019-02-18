using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update ()
	{

	}
	public void PlayGame()
	{
		//Play the game
		Application.LoadLevel(1);
	}
	public void Options()
	{
		//How to play
		Application.LoadLevel(3);
	}
	public void MainMenu()
	{
		//How to play
		Application.LoadLevel(0);
	}
	public void QuitGame()
	{
		//Quit the game and closed out of screen.
		Application.Quit();
	}

}