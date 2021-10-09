using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The parent class of all UI panels, containing state information for the UI panel
/// </summary>
public abstract class BasePanel
{
    /// <summary>
    /// The UI information
    /// </summary>
    public UIType UIType { get; private set; }
    /// <summary>
    /// UI Management tools
    /// </summary>
    public UITool UITool { get; private set; }
    /// <summary>
    /// Panel manager
    /// </summary>
    public PanelManager PanelManager { get; private set; }

    public BasePanel(UIType uIType)
    {
        UIType = uIType;
    }

    /// <summary>
    /// Initialize UITool
    /// </summary>
    /// <param name="tool"></param>
    public void Initialize(UITool tool)
    {
        UITool = tool;
    }

    /// <summary>
    /// Initialize the panel manager
    /// </summary>
    /// <param name="panelManager"></param>
    public void Initialize(PanelManager panelManager)
    {
        PanelManager = panelManager;
    }

    /// <summary>
    /// Operations performed when the UI enters are performed only once
    /// </summary>
    public virtual void OnEnter() { }

    /// <summary>
    /// Actions performed when the UI pauses
    /// </summary>
    public virtual void OnPause() { }

    /// <summary>
    /// Actions performed while the UI continues
    /// </summary>
    public virtual void OnResume() { }

    /// <summary>
    /// Operations performed when the UI exits
    /// </summary>
    public virtual void OnExit() { }
}
