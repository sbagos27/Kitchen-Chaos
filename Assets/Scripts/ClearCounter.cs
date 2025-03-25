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
            } else {
                //player not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
