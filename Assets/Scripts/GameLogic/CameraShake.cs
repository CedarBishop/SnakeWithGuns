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
        Vector3 originalPosition = transform.position;
        float timeElapsed = 0.0f;

        while (timeElapsed < cameraShakeDuration)
        {
            float x = Random.Range(-1.0f, 1.0f) * cameraShakeMagnitude;
            float z = Random.Range(-1.0f, 1.0f) * cameraShakeMagnitude;

            transform.position += new Vector3(x, 0, z);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = originalPosition;
    }


}
