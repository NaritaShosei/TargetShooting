using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public static PanelManager Instance;
    [SerializeField]
    List<ScorePanel> _panels = new();
    Dictionary<ScorePanel, bool> _dic = new();
    [SerializeField]
    List<Transform> _targets = new();
    int _index;
    float _moveSpeed = 1;
    void Start()
    {
        Instance = this;
        foreach (var item in _panels)
        {
            _dic.Add(item, true);
        }
    }
    private void Update()
    {
        var dir = _targets[_index].position - transform.position;
        transform.position += dir.normalized * _moveSpeed * Time.deltaTime;
        if ((_targets[_index].position - transform.position).magnitude < 0.3f)
        {
            _index = (_index + 1) % _targets.Count;
        }
    }
    public bool ValueChange(ScorePanel panel)
    {
        _dic[panel] = false;
        return _dic.Values.All(x => !x);
    }
}
