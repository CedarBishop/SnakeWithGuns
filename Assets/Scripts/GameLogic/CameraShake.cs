using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    private float cameraShakeMagnitude;
    private float cameraShakeDuration;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void StartShake(float magnitude, float duration)
    {
        cameraShakeMagnitude = magnitude;
        cameraShakeDuration = duration;
        StartCoroutine("Shake");
    }

    public void StopShake()
    {
        StopCoroutine("Shake");
    }

    private IEnumerator Shake()
    {
        Vector3 originalPosition = transform.localPosition;
        Vector3 originalRotation = transform.localRotation.eulerAngles;

        float timeElapsed = 0.0f;

        while (timeElapsed < cameraShakeDuration)
        {
            float x = Random.Range(-1.0f, 1.0f) * cameraShakeMagnitude;
            float y = Random.Range(-1.0f, 1.0f) * cameraShakeMagnitude;
            float Z = Random.Range(-1.0f, 1.0f) * cameraShakeMagnitude;    // Rotation

            //transform.localPosition = new Vector3(x, transform.localPosition.y, y);
            transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, Z);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.localRotation = Quaternion.Euler(originalRotation);
        transform.localPosition = originalPosition;
    }


}
