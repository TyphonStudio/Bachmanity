using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class QualitySettingsDropdown : MonoBehaviour {

    private Dropdown myDropdown;

    private void Awake()
    {
        myDropdown = GetComponent<Dropdown>();
    }

    void Start()
    {
        myDropdown.value = QualitySettings.GetQualityLevel();
    }
}
