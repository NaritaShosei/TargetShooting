using System.Collections.Generic;
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
    public void ValueChange(ScorePanel panel)
    {
        if (!_dic.ContainsKey(panel)) return;
        _dic[panel] = false;
    }
}
