using System.Collections;
using UnityEngine;

public class CameraShaker : MonoBehaviour {

    public static CameraShaker Instance { get; private set; }

    Camera mainCamera;

    Vector3 beforeShake;
    Vector3 framePosition;
    float timeElapsed;

    private void Awake()
    {
        Instance = this;
        mainCamera = Camera.main;
    }

    public void ShakeMainCameraOnce(float duration, float magnitude)
    {
        StartCoroutine(Shake(duration, magnitude));
    }

    IEnumerator Shake(float duration, float magnitude)
    {
        beforeShake = mainCamera.transform.position;
        timeElapsed = 0.0f;

        while(timeElapsed < duration)
        {
            framePosition.x = Random.Range(-1f, 1f) * magnitude;
            framePosition.y = Random.Range(-1f, 1f) * magnitude;
            framePosition.z = beforeShake.z;

            mainCamera.transform.position = framePosition;

            timeElapsed += Time.deltaTime;

            yield return null;
        }

        mainCamera.transform.position = beforeShake;
    }
}
