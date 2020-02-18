using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image image = null;
    [SerializeField] private TextMeshProUGUI health = null;

    private float maxWidth;
    private HealthData healthData;

    private void Awake()
    {
        maxWidth = image.rectTransform.sizeDelta.x;
    }

    public void SetHealth(HealthData input)
    {
        healthData = input;
        TextUpdate();
        ImageUpdate();
    }

    public void UpdateHealth()
    {
        TextUpdate();
        ImageUpdate();
    }

    private void TextUpdate()
    {
        health.SetText(healthData.Health.ToString("0") + "/" + healthData.MaxHealth.ToString("0"));
    }
    private void ImageUpdate()
    {
        image.rectTransform.sizeDelta = new Vector2(CodeLibrary.Remap(healthData.Absolute, 0, 1, 0, maxWidth), image.rectTransform.sizeDelta.y);
    }
}
