using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCManager : MonoBehaviour
{
    static public NPCManager Singleton;

    private int _enemiesKilled;
    private int _civiliansKilled;
    private int _maxEnemiesKillable = 4;
    private int _maxCivilianKillable = 3;

    private bool _isChangingScene;

    private void Awake()
    {
        Singleton = this;
    } 
    

    public void IncrementKilledEnemies()
    {
        _enemiesKilled++;
        Debug.Log("Nemici uccisi: " + _enemiesKilled);
        if (_enemiesKilled >= _maxEnemiesKillable)
        {
            ChangeScene(2);
        }
    }

    public void IncrementKilledCivilians()
    {
        _civiliansKilled++;
        Debug.Log("Civili uccisi: " + _civiliansKilled);
        if (_civiliansKilled >= _maxCivilianKillable)
        {
            ChangeScene(3);
        }
    }

    public void ChangeScene(int sceneIndex)
    {
        if (_isChangingScene) return;

        _enemiesKilled = 0;
        _civiliansKilled = 0;

        _isChangingScene = true;

        SceneManager.LoadScene(sceneIndex);
        enabled = false;
    }


}
