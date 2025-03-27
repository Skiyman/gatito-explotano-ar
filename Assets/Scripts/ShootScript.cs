using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject bulletPrefab;  // Префаб пули
    public GameObject pelletPrefab; // Префаб дроби

    [Header("ShootSettings")]
    public int pelletAmount = 10; // Количество дробинок
    private bool isShotgunMode = false;

    public void ToggleShootMode()
    {
        isShotgunMode = !isShotgunMode;
    }

    public void OnShootButtonPressed() {
        if (isShotgunMode) {
            Shoot(pelletPrefab, pelletAmount);
        }
        else {
            Shoot(bulletPrefab, 1);
        }
    }

    public void Shoot(GameObject enemy, int count) {
        // Берём актуальную камеру
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            for (int i = 0; i < count; i++) {
                // Создаём пулю в текущей позиции камеры с её направлением
                GameObject pelletInstance = Instantiate(
                    enemy, 
                    mainCamera.transform.position,
                    mainCamera.transform.rotation
                );
            }
        }
        else
        {
            Debug.LogError("Главная камера не найдена!");
        }
    }
}
