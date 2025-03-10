
using Cysharp.Threading.Tasks;
using UnityEngine;

public class PanelBase : MonoBehaviour
{
    private async void OnCollisionEnter(Collision collision)
    {
        if (!GamaManager.Instance.IsConflicted && collision.gameObject.CompareTag("Player"))
        {
            await Collision();
        }
    }

    protected virtual async UniTask Collision()
    {
        GamaManager.Instance.Conflict(true);
        await GamaManager.Instance.Reset();
    }
}
