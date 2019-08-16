using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    // Reference to Input Field
    [SerializeField] TMP_InputField _inputField;

    // Reference to InputOutput component for save player name.
    [SerializeField] InputOutput _inputOutput;

    //Load next scene in build settings.
    //Calls by pressing PlayButton. Using in OnClick() Event;
    public void PlayGame()
    {
        int beginLevelScore = 0;
        Debug.Log(_inputField.placeholder.GetComponent<TextMeshProUGUI>().text);
        if (_inputField.placeholder.IsActive()) _inputOutput.SaveData("Player", beginLevelScore);
        else _inputOutput.SaveData(_inputField.text, beginLevelScore);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Quit game function.
    // Calls by pressing QuitButton. Using in OnClick() Event.
    public void QuitGame()
    {
        Application.Quit();
    }
}
