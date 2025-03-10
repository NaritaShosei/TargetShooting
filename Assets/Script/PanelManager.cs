using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public static PanelManager Instance;
    [SerializeField]
    List<ScorePanel> _panels = new();
    Dictionary<ScorePanel, bool> _dic = new();
    void Start()
    {
        Instance = this;
        foreach (var item in _panels)
        {
            _dic.Add(item, true);
        }
    }
    public bool ValueChange(ScorePanel panel)
    {
        _dic[panel] = false;
        return _dic.Values.All(x => !x);
    }
}
