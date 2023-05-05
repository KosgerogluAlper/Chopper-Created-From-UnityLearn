using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DiffucilyButton : MonoBehaviour
{
    GameManager gameManager;
    private Button button;
    [SerializeField] private float diffuciltyIndex;

    void Awake()
    {
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
        button = GetComponent<Button>();
    }
    void Start()
    {
        button.onClick.AddListener(SetDiffucilty);
    }
    void SetDiffucilty()
    {
        gameManager.StartGame(diffuciltyIndex);
    }

}
