using UnityEngine;

public class GamaManager : MonoBehaviour
{
    public static GamaManager Instance { get; private set; }
    private float _score;
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

    }
}
