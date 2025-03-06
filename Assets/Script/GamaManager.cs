using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamaManager : MonoBehaviour
{
    public static GamaManager Instance { get; private set; }
    private float _score;
    public bool IsConflicted;
    public Action ResetEvent;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(float value)
    {
        _score += value;
    }
    public void SceneChange(string name)
    {
        SceneManager.LoadScene(name);
        ResetEvent = null;
    }
    public void Conflict()
    {
        IsConflicted = true;
    }
    public void PositionSet()
    {
        ResetEvent?.Invoke();
    }
}
