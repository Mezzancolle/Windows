using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MainMenuManager : MonoBehaviour
{
    private AudioSource _myAudioSource;

    private void Start()
    {
        _myAudioSource = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        _myAudioSource.Play();

        StartCoroutine(WaitOneSecondAndStartGame());
    }

    public void QuitGame()
    {
        _myAudioSource.Play();

        StartCoroutine(WaitOneSecondAndQuitGame());
    }

    IEnumerator WaitOneSecondAndQuitGame()
    {
        yield return new WaitForSeconds(1.0f);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    IEnumerator WaitOneSecondAndStartGame()
    {
        yield return new WaitForSeconds(1.0f);
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(1);
    }
}
