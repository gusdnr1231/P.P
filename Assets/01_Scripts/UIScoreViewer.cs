using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScoreViewer : MonoBehaviour
{
    [SerializeField] Player player;
    TextMeshProUGUI textMeshPro;

    void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textMeshPro.text = $"Score: {player.Score}";
    }
}
