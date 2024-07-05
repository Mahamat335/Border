
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

    private static readonly Color handleColor = new Color(141f / 255f, 141f / 255f, 141f / 255f);

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
            Color currentColorR = MWRotaterR.GetComponentInChildren<Renderer>().material.GetColor("_Color");
            Color currentColorL = MWRotaterL.GetComponentInChildren<Renderer>().material.GetColor("_Color");

            if (camYRot >= 130 && camYRot <= 140) {
                highlight(MWRotaterR, Color.white);
                ControlWindow(MWRotaterR, glass_backR, ref isRotatingR);

            }
            else if (camYRot >= 40 && camYRot <= 50) {
                highlight(MWRotaterL, Color.white);
                ControlWindow(MWRotaterL, glass_backL, ref isRotatingL);

            }
            else if (currentColorR.r == 1f && currentColorR.g == 1f && currentColorR.b == 1f) {
                highlight(MWRotaterR, handleColor);
            }
            else if (currentColorL.r == 1f && currentColorL.g == 1f && currentColorL.b == 1f) {
                highlight(MWRotaterL, handleColor);
            }


        }



    }

    private void ControlWindow(GameObject rotater, GameObject glass, ref bool isRotating)
    {

        if (Input.GetKey(KeyCode.S) && !isRotating && glass.transform.localPosition.y > 0.71f)
        {

            StartCoroutine(

                RotateAndMove(rotater, glass, -rotationSpeed, -movementSpeed, isRotating)

            );

        }
        else if (Input.GetKey(KeyCode.W) && !isRotating && glass.transform.localPosition.y < 1.0f)
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

        while ((Input.GetKey(KeyCode.S) && rotSpeed < 0) || (Input.GetKey(KeyCode.W) && rotSpeed > 0))
        {
            

            float newY = glass.transform.localPosition.y + moveSpeed * Time.fixedDeltaTime;
            if (newY < 0.71f)
                break;
            if (newY > 1)
                break;
            rotater.transform.localEulerAngles += new Vector3(0, 0, rotSpeed * Time.fixedDeltaTime);
            glass.transform.localPosition = new Vector3(
                glass.transform.localPosition.x,
                newY,
                glass.transform.localPosition.z
            );

            yield return new WaitForFixedUpdate();
        }

        isRotating = false;

    }

    private void highlight(GameObject selection, Color color) {

        Renderer[] rs = selection.GetComponentsInChildren<Renderer>();

        foreach (Renderer r in rs) {
            r.material.SetColor("_Color", color);
        }

    }

}


