using Cysharp.Threading.Tasks;
using System.Collections;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField]
    float _score;
    private async void OnCollisionEnter(Collision collision)
    {
        if (!GamaManager.Instance.IsConflicted && collision.gameObject.CompareTag("Player"))
        {
            GamaManager.Instance.AddScore(_score);
            Debug.Log("AddScore");
            GamaManager.Instance.Conflict(true);
            Debug.Log("Conflict");
            await GamaManager.Instance.Reset();
            Debug.Log("Reset");
        }
    }
}
