using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitPad : MonoBehaviour
{
    private GameManager gameManager;
    private Button button;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(gameManager.HitSlime);
    }
}
