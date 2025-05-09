using System;
using UnityEngine;

public class ContainerCounter : BaseCounter {

    public event EventHandler OnPlayerGrabbedObject;
    
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    
    public override void Interact(Player player) {
        if (!player.HasKitchenObject()) {
            //player has nothing
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);
            
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }
}
