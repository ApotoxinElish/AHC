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
    /// <summary>
    /// The UI manager
    /// </summary>
    public UIManager UIManager { get; private set; }

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
    /// Initialize the UI manager
    /// </summary>
    /// <param name="uIManager"></param>
    public void Initialize(UIManager uIManager)
    {
        UIManager = uIManager;
    }

    /// <summary>
    /// Operations performed when the UI enters are performed only once
    /// </summary>
    public virtual void OnEnter() { }

    /// <summary>
    /// Actions performed when the UI pauses
    /// </summary>
    public virtual void OnPause()
    {
        UITool.GetOrAddComponent<CanvasGroup>().blocksRaycasts = false;
    }

    /// <summary>
    /// Actions performed while the UI continues
    /// </summary>
    public virtual void OnResume()
    {
        UITool.GetOrAddComponent<CanvasGroup>().blocksRaycasts = true;
    }

    /// <summary>
    /// Operations performed when the UI exits
    /// </summary>
    public virtual void OnExit()
    {
        UIManager.DestroyUI(UIType);
    }

    /// <summary>
    /// Show a panel
    /// </summary>
    /// <param name="panel"></param>
    public void Push(BasePanel panel) => PanelManager?.Push(panel);

    /// <summary>
    /// Close a panel
    /// </summary>
    public void Pop() => PanelManager?.Pop();
}
