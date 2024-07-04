using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarShake : MonoBehaviour {

    public bool isDriving = true;

    public float shakeIntensity = 0.05f;
    public float shakeFrequency = 3f;
    private Vector3 initialPosition;

    void FixedUpdate() {
        if (isDriving) {
            Shake();
        }
    }
    private void Shake() {

        float shakeAmountX = Mathf.PerlinNoise(0f, Time.time * shakeFrequency) * 2f - 1f;
        float shakeAmountY = Mathf.PerlinNoise(10f, Time.time * shakeFrequency) * 2f - 1f;

        Vector3 targetPosition = initialPosition + new Vector3(shakeAmountX, shakeAmountY, 0f) * shakeIntensity;
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.fixedDeltaTime * 5f);

    }

}
