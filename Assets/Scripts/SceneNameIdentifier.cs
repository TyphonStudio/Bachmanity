using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNameIdentifier : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI sceneNameText;

	void Start()
	{
        sceneNameText.text = SceneManager.GetActiveScene().name;
	}
}
