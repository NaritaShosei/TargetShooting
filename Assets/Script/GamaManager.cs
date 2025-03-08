using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamaManager : MonoBehaviour
{
    public static GamaManager Instance { get; private set; }
    private float _score;
    public bool IsConflicted { get => _isConflicted; }
    private bool _isConflicted;
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
    }
    public void Conflict(bool flg)
    {
        _isConflicted = flg;
    }
    public void PositionReset()
    {
        ResetEvent?.Invoke();
    }
    public async UniTask Reset()
    {
        await UniTask.Delay(2500);
        PositionReset();
    }
}
