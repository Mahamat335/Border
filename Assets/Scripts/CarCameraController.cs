using UnityEngine;

public class CarCameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public float xClamp = 80;
    public float yClamp = 30;

    private float xRotation = 0f;
    private float yRotation = 0f;
    public float crouchingSpeed = 3f;
    private Vector3 defaultPosition = new Vector3(-1.0f, 1, 0);
    private Vector3 crouchedPosition = new Vector3(-0.2f, 0.2f, 0.0f);


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.rotation = Quaternion.Euler(0, 90, 0f);
    }

    void LateUpdate()
    {
        LookAround();
        Move();
    }

    private void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, 0, xClamp);
        yRotation = Mathf.Clamp(yRotation, -yClamp, yClamp);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation + 90, 0f);

        if (transform.localRotation.eulerAngles.x > 55.0f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, defaultPosition - crouchedPosition, Time.deltaTime * crouchingSpeed);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, defaultPosition, Time.deltaTime * crouchingSpeed);
        }
    }

    private void Move()
    {
        //move
    }
}
