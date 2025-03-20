using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject bulletPrefab;  // Префаб пули
    public float bulletSpeed = 20f;  // Скорость пули

    public void Shoot()
    {
        // Берём актуальную камеру
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            // Создаём пулю в текущей позиции камеры с её направлением
            GameObject bulletInstance = Instantiate(bulletPrefab, mainCamera.transform.position, mainCamera.transform.rotation);

            // Получаем Rigidbody и придаём начальную скорость в направлении камеры
            Rigidbody rb = bulletInstance.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = mainCamera.transform.forward * bulletSpeed;
            }

            // Уничтожаем пулю через 10 секунд
            Destroy(bulletInstance, 5f);
        }
        else
        {
            Debug.LogError("Главная камера не найдена!");
        }
    }
}
