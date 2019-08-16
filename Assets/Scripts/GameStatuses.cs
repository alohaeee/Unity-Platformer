using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


// Represent all Game's Status
public enum GameStatus
{
    Playing,
    GameEnd,
    Paused,
    LevelEnd,
    LastLevel
};
public class GameStatuses : MonoBehaviour
{
    // Current Game's Status.
    GameStatus _gameStatus;

    // Build index of menu chosen at Build Settings.
    [SerializeField] int _menuBuildIndex = 0;
    // Reference to PlayerPersist component for saving or transfer data.
    [SerializeField] PlayerPersist _playerPersist;
    // Event system for class methods. Simply turn on GUI Panels in my implementation.
    public UnityEvent pauseEvent;
    public UnityEvent resumeEvent;
    public UnityEvent gameEndEvent;
    public UnityEvent levelEndEvent;
    public UnityEvent lastLevelEvent;

    private void Start  ()
    {
        _gameStatus = GameStatus.Playing;
    }
    private void Update()
    {
        // Possibility to Pause and Resume game by pressing EscapeButton
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (_gameStatus == GameStatus.Playing) Pause();
            else if (_gameStatus == GameStatus.Paused) Resume();
        }
    }

    // Return current Game Status
    public GameStatus Status()
    {
        return _gameStatus;
    }

    // Invoke End Game Event, change Game Status to Game End.
    public void EndGame()
    {
        gameEndEvent.Invoke();
        _gameStatus = GameStatus.GameEnd;
    }

    // Invoke Pauese Event, change Game Status to Pause and turn Time Scale to 0.
    public void Pause()
    {
        pauseEvent.Invoke();
        _gameStatus = GameStatus.Paused;
        Time.timeScale = 0f;
        
    }

    // Invoke Resume Event, change Game Status to Playing and return Time Scale to 1.
    public void Resume()
    {
        resumeEvent.Invoke();
        _gameStatus = GameStatus.Playing;
        Time.timeScale = 1f;
    }

    // Check if next scene is exist with compare Scene count in build settings.
    // If True then Invoke level End Event. False then invoke last Level Event.
    // Change game status to LevelEnd or LastLevel.
    public void FinishLevel()
    {
        bool hasMoreLevels = SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings;
        if (hasMoreLevels)
        {
            levelEndEvent.Invoke();
            _gameStatus = GameStatus.LevelEnd;
        }
        else
        {
            lastLevelEvent.Invoke();
            _gameStatus = GameStatus.LastLevel;
        }
        
    }

    // Load current scene with Scene Manager.
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Load menu scene with Scene Manager using Menu Build Index.
    // Save player data to Table using Player Persist component's method SavePlayerToTable().
    public void BackToMenu()
    {
        if(_gameStatus == GameStatus.Paused) Resume();
        else if(_gameStatus != GameStatus.Playing)
        {
            _playerPersist.SavePlayerToTable();
        }
        SceneManager.LoadScene(_menuBuildIndex);
    }

    // Quit the game.
    public void Quit()
    {
        Application.Quit();
    }
    // Load next scene with transfer player data.
    public void NextLevel()
    {
        _playerPersist.TransferData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
}

