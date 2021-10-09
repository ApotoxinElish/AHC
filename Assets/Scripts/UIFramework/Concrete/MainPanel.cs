using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The main panel of the main scene
/// </summary>
public class MainPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/MainPanel";

    public MainPanel() : base(new UIType(path)) { }

    public override void OnEnter()
    {

    }
}
