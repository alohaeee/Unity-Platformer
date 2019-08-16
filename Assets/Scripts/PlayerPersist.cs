using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPersist : MonoBehaviour
{
    DataPlayer _dataPlayer;
    [SerializeField] InputOutput _inputOutput;
    private void Awake()
    {
        _dataPlayer = GetComponent<DataPlayer>();
        _inputOutput.GetData(ref _dataPlayer.playerName, ref _dataPlayer.beginLevelScore);
    }

    public void TransferData()
    {
        _inputOutput.SaveData(_dataPlayer.playerName, _dataPlayer.beginLevelScore);
    }

    public void SavePlayerToTable()
    {
        _inputOutput.SavePlayer(_dataPlayer.playerName, _dataPlayer.score, SceneManager.GetActiveScene().name);
    }
}
