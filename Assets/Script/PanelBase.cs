using Cysharp.Threading.Tasks;
using System.Collections;
using UnityEngine;

public class PanelBase : MonoBehaviour
{
    private async void OnCollisionEnter(Collision collision)
    {
        if (!GamaManager.Instance.IsConflicted && collision.gameObject.CompareTag("Player"))
        {
            Collision();
            await GamaManager.Instance.Reset();
        }
    }

    protected virtual void Collision()
    {
        GamaManager.Instance.Conflict(true);
    }
}
