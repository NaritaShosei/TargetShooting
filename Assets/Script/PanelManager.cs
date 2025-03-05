using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField]
    float _score;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GamaManager.Instance.AddScore(_score);
        }
    }
}
