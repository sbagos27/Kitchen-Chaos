using System;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour{
    [SerializeField] private TextMeshProUGUI recipesDeliverText;
    
    private void Start() {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;

        Hide();
    }

    private void GameManager_OnStateChanged(object sender, EventArgs e) {
        if (GameManager.Instance.IsGameOver()) {
            Show();
            
            recipesDeliverText.text = DeliveryManager.Instance.GetSuccessRecipesAmount().ToString();
        } else {
            Hide();
        }
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

    private void Show() {
        gameObject.SetActive(true);
    }
}
