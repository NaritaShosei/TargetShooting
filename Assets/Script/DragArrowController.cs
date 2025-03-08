using Unity.VisualScripting;
using UnityEngine;

public class DragArrowController : MonoBehaviour
{
    [SerializeField]
    Transform _origin;
    [SerializeField]
    GameObject _obj;
    Vector2 _startPos;
    Vector2 _endPos;
    LineRenderer _line;
    [SerializeField]
    float _cameraDistance;
    [SerializeField]
    float _power;
    [SerializeField]
    float _maxPower = 5;
    Rigidbody _rb;
    bool _isShoot;
    void Start()
    {
        _line = GetComponent<LineRenderer>();
        _rb = _obj.GetComponent<Rigidbody>();
    }

    void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = _cameraDistance;
        var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        if (!_isShoot)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GamaManager.Instance.ResetEvent += SetPosition;
                _line.enabled = true;
                _startPos = worldPos;
                worldPos.z = -3;
                _line.SetPosition(0, worldPos);
            }
            else if (Input.GetMouseButton(0))
            {
                worldPos.z = -3;
                _line.SetPosition(1, worldPos);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _endPos = worldPos;
                var force = Vector2.ClampMagnitude(_startPos - _endPos, _maxPower);
                _rb.useGravity = true;

                _rb.AddForce(_obj.transform.up * force.y + _obj.transform.right * force.x, ForceMode.Impulse);
                _line.enabled = false;
                _isShoot = true;
            }
        }
    }
    void SetPosition()
    {
        _rb.linearVelocity = Vector3.zero;
        GamaManager.Instance.Conflict(false);
        _isShoot = false;
        _rb.useGravity = false;
        _obj.transform.position = _origin.position;
    }
    private void OnDisable()
    {
        GamaManager.Instance.ResetEvent -= SetPosition;
    }
}
