using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeModelSwitcher : MonoBehaviour
{
    public static TreeModelSwitcher Instance { get; private set; }

    public GameObject treeNoLights;
    public GameObject treeWithLights;

    bool lightsOn = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SetLightsState(false);
    }

    public void ToggleModels()
    {
        lightsOn = !lightsOn;
        SetLightsState(lightsOn);
    }

    void SetLightsState(bool turnOn)
    {
        if (treeNoLights != null)
            treeNoLights.SetActive(!turnOn);

        if (treeWithLights != null)
            treeWithLights.SetActive(turnOn);
    }
}
