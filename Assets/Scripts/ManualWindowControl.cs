
using UnityEngine;
using System.Collections;

public class ManualWindowControl : MonoBehaviour
{

    public GameObject MWRotaterR;
    public GameObject glass_backR;
    public GameObject MWRotaterL;
    public GameObject glass_backL;
    public Camera mainCamera;

    public float rotationSpeed = 6f;
    public float movementSpeed = 0.058f;

    private bool isRotatingR = false;
    private bool isRotatingL = false;

    void FixedUpdate()
    {

        CheckAndControlWindow();

    }

    private void CheckAndControlWindow()
    {

        float camYRot = mainCamera.transform.eulerAngles.y;
        float camXRot = mainCamera.transform.eulerAngles.x;

        if (camXRot >= 30 && camXRot < 55)
        {

            if (camYRot >= 115 && camYRot <= 125)
            {

                ControlWindow(MWRotaterR, glass_backR, ref isRotatingR);

            }
            else if (camYRot >= 55 && camYRot <= 65)
            {

                ControlWindow(MWRotaterL, glass_backL, ref isRotatingL);

            }

        }

    }

    private void ControlWindow(GameObject rotater, GameObject glass, ref bool isRotating)
    {

        if (Input.GetKey(KeyCode.W) && !isRotating && glass.transform.localPosition.y > 0.71f)
        {

            StartCoroutine(

                RotateAndMove(rotater, glass, -rotationSpeed, -movementSpeed, isRotating)

            );

        }
        else if (Input.GetKey(KeyCode.S) && !isRotating && glass.transform.localPosition.y < 1.0f)
        {

            StartCoroutine(RotateAndMove(rotater, glass, rotationSpeed, movementSpeed, isRotating));

        }

    }

    private IEnumerator RotateAndMove(

        GameObject rotater,
        GameObject glass,
        float rotSpeed,
        float moveSpeed,
        bool isRotating

    )
    {
        isRotating = true;

        while ((Input.GetKey(KeyCode.W) && rotSpeed < 0) || (Input.GetKey(KeyCode.S) && rotSpeed > 0))
        {
            rotater.transform.localEulerAngles += new Vector3(0, 0, rotSpeed * Time.fixedDeltaTime);

            float newY = glass.transform.localPosition.y + moveSpeed * Time.fixedDeltaTime;
            if (newY < 0.71f)
                break;
            if (newY > 1)
                break;
            glass.transform.localPosition = new Vector3(
                glass.transform.localPosition.x,
                newY,
                glass.transform.localPosition.z
            );

            yield return new WaitForFixedUpdate();
        }

        isRotating = false;

    }
}


