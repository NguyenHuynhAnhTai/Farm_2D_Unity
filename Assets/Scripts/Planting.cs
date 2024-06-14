using System.Collections;
using UnityEngine;

public class Planting : MonoBehaviour
{
    public GameObject[] plantStages; // Mảng các đối tượng cây tương ứng với các giai đoạn phát triển
    public Transform plantPosition; // Vị trí trồng cây trên ô ruộng

    private int _currentStage = 0;
    private const float GrowTime = 240f; // 4 phút
    private bool _isPlanted = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isPlanted) // Kiểm tra phím trồng cây và ô chưa có cây
        {
            PlantSeed();
        }
    }

    void PlantSeed()
    {
        _isPlanted = true;
        GameObject seed = Instantiate(plantStages[0], plantPosition.position, Quaternion.identity);
        StartCoroutine(GrowPlant(seed));
    }

    IEnumerator GrowPlant(GameObject seed)
    {
        while (_currentStage < plantStages.Length)
        {
            yield return new WaitForSeconds(GrowTime / plantStages.Length);
            Destroy(seed);
            seed = Instantiate(plantStages[_currentStage], plantPosition.position, Quaternion.identity);
            _currentStage++;
        }
    }

    void OnMouseDown()
    {
        if (_currentStage == plantStages.Length)
        {
            HarvestPlant();
        }
    }

    void HarvestPlant()
    {
        // Thực hiện hành động thu hoạch
        Debug.Log("Plant Harvested!");
        Destroy(plantPosition.GetChild(0).gameObject);
        _currentStage = 0;
        _isPlanted = false;
    }
}