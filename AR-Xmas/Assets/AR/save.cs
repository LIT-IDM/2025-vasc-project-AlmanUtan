using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeModelSwitcher1 : MonoBehaviour
{
    public static TreeModelSwitcher1 Instance { get; private set; }

    public GameObject treeNoLights;
    public GameObject treeWithLights;

    private bool lightsOn = false;

    private void Awake()
    {
        // Simple singleton for the currently spawned tree
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("Multiple TreeModelSwitcher instances found! Destroying duplicate.");
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        SetLightsState(false); // Start with no lights
    }

    public void ToggleModels()
    {
        lightsOn = !lightsOn;
        SetLightsState(lightsOn);
    }

    private void SetLightsState(bool turnOn)
    {
        if (treeNoLights != null)
            treeNoLights.SetActive(!turnOn);

        if (treeWithLights != null)
            treeWithLights.SetActive(turnOn);
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
}