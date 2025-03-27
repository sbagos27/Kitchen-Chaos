using System;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject {

    public event EventHandler<OnIngridientAddedEventArgs> OnIngridientAdded;

    public class OnIngridientAddedEventArgs : EventArgs {
        public KitchenObjectSO kitchenObjectSO;
    }
    
    [SerializeField] private List<KitchenObjectSO> validKitchenObjectsSOList;
    
    private List<KitchenObjectSO> kitchenObjectSOList;

    private void Awake() {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }

    public bool TryAddIngridient(KitchenObjectSO kitchenObjectSO) {
        if (!validKitchenObjectsSOList.Contains(kitchenObjectSO)) {
            return false;
        }
        if (kitchenObjectSOList.Contains(kitchenObjectSO)) {
            return false;
        } else {
            kitchenObjectSOList.Add(kitchenObjectSO);
            
            OnIngridientAdded?.Invoke(this, new OnIngridientAddedEventArgs {
                kitchenObjectSO = kitchenObjectSO
            });
            
            return true;
        }
    }
}
