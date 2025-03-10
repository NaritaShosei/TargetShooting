using Cysharp.Threading.Tasks;
using UnityEngine;

public class ScorePanel : PanelBase
{
    [SerializeField]
    float _score;
    protected override async UniTask Collision()
    {
        GamaManager.Instance.Conflict(true);
        GamaManager.Instance.AddScore(_score);
        gameObject.SetActive(false);
        if (PanelManager.Instance.ValueChange(this))
        {
            await UniTask.Delay(2000);
            GamaManager.Instance.SceneChange("InGame");
        }
        else
        {
            await GamaManager.Instance.Reset();
        }
    }
}
