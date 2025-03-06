using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField]
    float _score;
    private void OnCollisionEnter(Collision collision)
    {
        if (!GamaManager.Instance.IsConflicted && collision.gameObject.CompareTag("Player"))
        {
            GamaManager.Instance.AddScore(_score);
            GamaManager.Instance.Conflict();
        }
    }
}
