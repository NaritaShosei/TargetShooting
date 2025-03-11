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
    float _maxDistance = 100;
    [SerializeField]
    float _minDistance;
    Rigidbody _rb;
    bool _isShoot;
    bool _isDrag;
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
                _isDrag = true;
            }
            else if (Input.GetMouseButton(0))
            {
                if (!_isDrag) return;
                worldPos.z = -3;
                _line.SetPosition(1, worldPos);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (!_isDrag) return;
                _endPos = worldPos;
                var force = Vector2.ClampMagnitude(_startPos - _endPos, _maxDistance);
                _rb.useGravity = true;

                _rb.AddForce((_obj.transform.up * force.y + _obj.transform.right * force.x) * _power, ForceMode.Impulse);
                _line.enabled = false;
                _isShoot = true;
                _isDrag = false;
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
