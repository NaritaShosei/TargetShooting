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
        if (Input.GetMouseButtonDown(0))
        {
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
            Vector3 forceVector = new Vector3(force.x, force.y, 1);

            _rb.AddForce(Vector3.Scale(_obj.transform.up, forceVector) * _power, ForceMode.Impulse);
            _line.enabled = false;
        }
    }
}
