using UnityEngine;

public class ScorePanel : PanelBase
{
    [SerializeField]
    float _score;
    protected override void Collision()
    {
        GamaManager.Instance.AddScore(_score);
        base.Collision();
    }
}
