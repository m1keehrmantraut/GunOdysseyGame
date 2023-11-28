using UnityEngine;

public class SpiralMovement : MonoBehaviour
{
    public float widthMin;         // Минимальная ширина эллипса
    public float widthMax;         // Максимальная ширина эллипса
    public float heightMin;        // Минимальная высота эллипса
    public float heightMax;        // Максимальная высота эллипса
    public float rotationSpeedMin; // Минимальная скорость вращения
    public float rotationSpeedMax; // Максимальная скорость вращения
    public float movementSpeedMin; // Минимальная скорость движения
    public float movementSpeedMax; // Максимальная скорость движения

    private float width;            // Ширина эллипса
    private float height;           // Высота эллипса
    private float rotationSpeed;    // Скорость вращения
    private float movementSpeed;    // Скорость движения
    private float angle;            // Текущий угол

    private void Start()
    {
        // Генерируем рандомные значения для ширины, высоты, скоростей и угла
        width = Random.Range(widthMin, widthMax);
        height = Random.Range(heightMin, heightMax);
        rotationSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);
        movementSpeed = Random.Range(movementSpeedMin, movementSpeedMax);
        angle = Random.Range(0f, 360f);

        // Устанавливаем начальное положение объекта на эллипсе
        transform.position = GetEllipsePosition(angle);
    }

    private void Update()
    {
        // Вращаем объект вокруг своей оси
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

        // Обновляем текущий угол
        angle += movementSpeed * Time.deltaTime;

        // Получаем новое положение объекта на эллипсе и перемещаем его туда
        Vector3 newPos = GetEllipsePosition(angle);
        transform.position = newPos;
    }

    private Vector3 GetEllipsePosition(float angle)
    {
        float rad = Mathf.Deg2Rad * angle;
        float x = width * Mathf.Cos(rad);
        float y = height * Mathf.Sin(rad);
        return new Vector3(x, y, 0f);
    }
}