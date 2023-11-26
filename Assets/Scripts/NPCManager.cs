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
    private float _countDownTimer = 180f;
    private float _countDownCounter;

    private bool _isChangingScene;

    private void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        _countDownCounter = _countDownTimer;
    }

    private void Update()
    {
        _countDownCounter -= Time.deltaTime;
        if (_countDownCounter <= 0)
        {
            ChangeScene(0);
        }
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
            ChangeScene(0);
        }
    }

    public void ChangeScene(int sceneIndex)
    {
        if (_isChangingScene) return;

        _enemiesKilled = 0;
        _civiliansKilled = 0;
        _countDownCounter = _countDownTimer;

        _isChangingScene = true;

        SceneManager.LoadScene(sceneIndex);
        enabled = false;
    }


}
