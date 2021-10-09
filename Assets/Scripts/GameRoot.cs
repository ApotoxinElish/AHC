using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Something to manage globally
/// </summary>
public class GameRoot : MonoBehaviour
{
    public static GameRoot Instance { get; private set; }
    /// <summary>
    /// Scenario manager
    /// </summary>
    public SceneSystem SceneSystem { get; private set; }

    private void Awake()
    {
        Instance = this;
        SceneSystem = new SceneSystem();
    }

    private void Start()
    {
        SceneSystem.SetScene(new StartScene());
    }
}
