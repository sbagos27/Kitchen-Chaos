using System;
using UnityEngine;

public class ContainerCounter : BaseCounter {

    public event EventHandler OnPlayerGrabbedObject;
    
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    
    public override void Interact(Player player) {
        if (!player.HasKitchenObject()) {
            //player has nothing
            Transform kitchenObjectTransfrom =  Instantiate(kitchenObjectSO.prefab);
            kitchenObjectTransfrom.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
            
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }
}
