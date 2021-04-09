using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public float baseHealth, baseSpeed;

    public void SetTextLabels()
    {
        TextMeshPro healthText = transform.Find("HealthText").GetComponent<TextMeshPro>();
        TextMeshPro speedText = transform.Find("SpeedText").GetComponent<TextMeshPro>();

        healthText.text = baseHealth.ToString();
        speedText.text = baseSpeed.ToString();
    }
}
