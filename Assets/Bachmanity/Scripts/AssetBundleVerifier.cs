using System.IO;
using UnityEngine;

public class AssetBundleVerifier : MonoBehaviour {

    [SerializeField]
    private string bundleName;

    [SerializeField]
    private string fileName;

    private void Start()
    {
        var bundle = AssetBundle.LoadFromFile(Path.Combine("AssetBundles/StandaloneWindows/", bundleName));
        if (bundle != null)
        {
            var prefab = bundle.LoadAsset(fileName);

            if (prefab != null)
                Debug.Log("asset exists in bundle");
            else
                Debug.LogError("no asset with this name found in the bundle");
        }
        else
        {
            Debug.LogError("no asset bundle found");
        }
    }
}
