using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[AddComponentMenu("Camera-Control/MouseLook")]
public class Mouse_Look : MonoBehaviour
{
    //переменные чувствительности мыши
    public float sesitivityX = 2f;
    public float sesitivityY = 2f;
    //переменные ограничения угла вращения по оси X
    public float minimumX = -360f;
    public float maximumX = 360f;
    //переменные ограничения угла вращения по оси Y
    public float minimumY = -360f;
    public float maximumY = 360f;

    //переменные определяющие текущий угол вращения
    float rotationX = 0f;
    float rotationY = 0f;

    //переменная содержащая тип вращения "Quaternion"
    Quaternion originalRotation;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        originalRotation = transform.localRotation;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }

    void Update()
    {
        //записываем угол поворота мыши с учетом чувствительности
        rotationX += Input.GetAxis("Mouse X") * sesitivityX;
        rotationY += Input.GetAxis("Mouse Y") * sesitivityY;

        //ограничения поворота
        rotationX = ClampAngle(rotationX, minimumX, maximumX);
        rotationY = ClampAngle(rotationY, minimumY, maximumY);

        //расчёт кватернионов
        Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.left);

        //поворот
        transform.localRotation = originalRotation * xQuaternion * yQuaternion;
    }
}
