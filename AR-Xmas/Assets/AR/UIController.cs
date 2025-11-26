using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    // Called by the UI Button OnClick
    public void OnLightsButtonPressed()
    {
        if (TreeModelSwitcher.Instance != null)
        {
            TreeModelSwitcher.Instance.ToggleModels();
        }
        else
        {
            Debug.LogWarning("OnLightsButtonPressed: TreeModelSwitcher.Instance is null. " +
                             "Is the marker in view and has the tree prefab spawned?");
        }
    }
}