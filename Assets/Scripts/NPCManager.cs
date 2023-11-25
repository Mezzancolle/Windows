using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCManager : MonoBehaviour
{
    private int _enemiesKilled;
    private int _civiliansKilled;
    private int _maxEnemiesKillable = 2;
    private int _maxCivilianKillable = 2;

    public void IncrementKilledEnemies()
    {
        _enemiesKilled++;
        Debug.Log("Nemici uccisi: " + _enemiesKilled);
        if (_enemiesKilled >= _maxEnemiesKillable)
        {
            ChangeScene();
        }
    }

    public void IncrementKilledCivilians()
    {
        _civiliansKilled++;
        Debug.Log("Civili uccisi: " + _civiliansKilled);
        if (_civiliansKilled >= _maxCivilianKillable)
        {
            ResetScene();
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(2);
    }

    public void ResetScene()
    {
        _enemiesKilled = 0;
        _civiliansKilled = 0;

        string CurrentScene = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(CurrentScene);
    }
}
