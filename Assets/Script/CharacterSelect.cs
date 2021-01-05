using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour {

	public void BackButton()
    {
        SceneManager.LoadScene(0);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
}
