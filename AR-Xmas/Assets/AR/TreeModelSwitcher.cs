using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeVariantSwitcher : MonoBehaviour
{
    public static TreeVariantSwitcher Instance { get; private set; }

    [System.Serializable]
    public class TreeVariant
    {
        public GameObject root;
        public GameObject noLights;
        public GameObject withLights;
    }

    public TreeVariant[] variants;

    [Range(0, 1)]
    public float sliderValue = 0f;

    private int currentVariantIndex = 0;
    private bool lightsOn = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("Multiple TreeVariantSwitcher instances found! Destroying duplicate.");
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        currentVariantIndex = 0;
        lightsOn = false;
        ApplyVariantAndLights();
    }

    public void ToggleLights()
    {
        lightsOn = !lightsOn;
        ApplyLightsState();
        Debug.Log("ToggleLights: lightsOn = " + lightsOn);
    }

    public void SetVariantBySlider(float value)
    {
        sliderValue = value;

        if (variants == null || variants.Length == 0)
        {
            Debug.LogWarning("SetVariantBySlider called but variants array is empty");
            return;
        }

        int newIndex = Mathf.Clamp(
            Mathf.RoundToInt(value * (variants.Length - 1)),
            0,
            variants.Length - 1
        );

        Debug.Log($"SetVariantBySlider: value={value}, newIndex={newIndex}, current={currentVariantIndex}");

        if (newIndex != currentVariantIndex)
        {
            currentVariantIndex = newIndex;
            ApplyVariantAndLights();
        }
    }

    private void ApplyVariantAndLights()
    {
        if (variants == null || variants.Length == 0)
            return;

        Debug.Log("ApplyVariantAndLights: currentVariantIndex=" + currentVariantIndex);

        for (int i = 0; i < variants.Length; i++)
        {
            if (variants[i].root != null)
            {
                bool active = (i == currentVariantIndex);
                variants[i].root.SetActive(active);
                Debug.Log($" - Set {variants[i].root.name} active = {active}");
            }
        }

        ApplyLightsState();
    }

    private void ApplyLightsState()
    {
        if (variants == null || variants.Length == 0)
            return;

        TreeVariant v = variants[currentVariantIndex];

        if (v.noLights != null)
            v.noLights.SetActive(!lightsOn);

        if (v.withLights != null)
            v.withLights.SetActive(lightsOn);
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
}
