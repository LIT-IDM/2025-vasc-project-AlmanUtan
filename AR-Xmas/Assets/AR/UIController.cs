using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public void OnLightsButtonPressed()
    {
        if (TreeVariantSwitcher.Instance != null)
        {
            TreeVariantSwitcher.Instance.ToggleLights();
        }
        else
        {
            Debug.LogWarning("OnLightsButtonPressed: TreeVariantSwitcher.Instance is null. " +
                             "Is the marker in view and has the tree prefab spawned?");
        }
    }

    public void OnVariantSliderChanged(float value)
    {
        Debug.Log("UIController.OnVariantSliderChanged: " + value);

        if (TreeVariantSwitcher.Instance != null)
        {
            TreeVariantSwitcher.Instance.SetVariantBySlider(value);
        }
        else
        {
            Debug.LogWarning("OnVariantSliderChanged: TreeVariantSwitcher.Instance is null. " +
                             "Is the marker in view and has the tree prefab spawned?");
        }
    }
}