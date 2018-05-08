using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class ResolutionsDropdown : MonoBehaviour {

    private Dropdown dropdown;

    Resolution[] resolutions;
    int currenResolutionIndex;

    List<string> resolutionNames = new List<string>();
    string indexName;

    private void Awake()
    {
        dropdown = GetComponent<Dropdown>();
    }

    private void Start()
    {
        UpdateResolutions();
        FillInDropdown();
        SubscribeToValueChange();
    }

    private void UpdateResolutions()
    {
        currenResolutionIndex = 0;

        resolutionNames.Clear();
        resolutions = Screen.resolutions;

        for (int i = 0; i < resolutions.Length; ++i)
        {
            if (AreResolutionsEqual(resolutions[i], Screen.currentResolution))
                currenResolutionIndex = i;

            indexName = resolutions[i].width + " x " + resolutions[i].height;
            resolutionNames.Add(indexName);
        }
    }

    private void FillInDropdown()
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(resolutionNames);
        dropdown.value = currenResolutionIndex;
        dropdown.RefreshShownValue();
    }

    private bool AreResolutionsEqual(Resolution one, Resolution two)
    {
        if (one.width == two.width && one.height == two.height)
            return true;

        return false;
    }

    private void SubscribeToValueChange()
    {
        dropdown.onValueChanged.AddListener(OnValueChange);
    }

    void OnValueChange(int value)
    {
        currenResolutionIndex = value;
        Screen.SetResolution(resolutions[currenResolutionIndex].width, resolutions[currenResolutionIndex].height, Screen.fullScreen);
    }
}
