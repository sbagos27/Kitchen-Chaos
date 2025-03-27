using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : BaseCounter {
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
        
    public override void Interact(Player player) {
        if (!HasKitchenObject()) {
            // no kitchenobject here
            if (player.HasKitchenObject()) {
                //player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            } else {
                //player not carrying anything
            }
        } else {
            // there is a kitchen object
            if (player.HasKitchenObject()) {
                //player has something
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) {
                    // player is holding a plate
                    if (plateKitchenObject.TryAddIngridient(GetKitchenObject().GetKitchenObjectSO())) {
                        GetKitchenObject().DestroySelf();
                    }
                } else {
                    //player is not carrying plate but has something else
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject)) {
                        // counter is holding plate
                        plateKitchenObject.TryAddIngridient(player.GetKitchenObject().GetKitchenObjectSO());
                        player.GetKitchenObject().DestroySelf();

                    }
                }
            } else {
                //player not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
