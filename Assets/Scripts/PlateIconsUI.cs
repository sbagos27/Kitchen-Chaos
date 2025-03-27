using System;
using UnityEngine;

public class PlateIconsUI : MonoBehaviour {
    
    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private Transform iconTemplate;


    // private void Awake() {
    //     iconTemplate.gameObject.SetActive(false);
    //     will cause the first item in the list to not show its icon until the second one is added
    // }
    private void Start() {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e) {
        UpdateVisual();
    }

    private void UpdateVisual() {
        foreach (Transform child in transform) {
            if (child == iconTemplate) continue;
            Destroy(child.gameObject);
            
        }
        
        foreach (KitchenObjectSO kitchenObjectSo in plateKitchenObject.GetKitchenObjectSOList()) {
            Transform iconTransform = Instantiate(iconTemplate, transform);
            iconTemplate.gameObject.SetActive(true);
            // Debug.Log(kitchenObjectSo);
            iconTransform.GetComponent<PlateIconSingleUI>().SetKitchenObjectSO(kitchenObjectSo);
        }
    }
}
