using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1CharacterSelection : MonoBehaviour {

    private GameObject[] CharacterList;
    private int index;

    private void Start()
    {
        index = PlayerPrefs.GetInt("Player1Character");

        CharacterList = new GameObject[transform.childCount];

        for(int i = 0; i < transform.childCount; i++)
        {
            CharacterList[i] = transform.GetChild(i).gameObject;
        }

        foreach(GameObject go in CharacterList)
        {
            go.SetActive(false);
        }

        if (CharacterList[index])
        {
            CharacterList[index].SetActive(true);
        }
    }

    public void ToggleLeft()
    {
        CharacterList[index].SetActive(false);

        index--;
        if(index < 0)
        {
            index = CharacterList.Length - 1;
        }

        CharacterList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        CharacterList[index].SetActive(false);

        index++;
        if (index == CharacterList.Length)
        {
            index = 0;
        }

        CharacterList[index].SetActive(true);
    }

    public void StartButton()
    {
        PlayerPrefs.SetInt("Player1Character", index);

        SceneManager.LoadScene(1);
    }
}
