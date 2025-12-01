using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DebugTrackedImages : MonoBehaviour
{
    private ARTrackedImageManager _manager;

    void Awake()
    {
        _manager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        _manager.trackedImagesChanged += OnChanged;
    }

    void OnDisable()
    {
        _manager.trackedImagesChanged -= OnChanged;
    }

    void OnChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var added in args.added)
        {
            Debug.Log($"Image added: {added.referenceImage.name}");
        }
    }
}
