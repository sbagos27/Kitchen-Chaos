using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;
    
    private KitchenObject kitchenObject;
    
    public void Interact(Player player) {
        if (kitchenObject == null) {
            Transform kitchenObjectTransfrom =  Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjectTransfrom.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        } else {
            //give object to player
            kitchenObject.SetKitchenObjectParent(player);

        }
    }

    public Transform GetKitchenObjectFollowTransform() {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject) {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject() {
        return kitchenObject;
    }

    public void ClearKitchenObject() {
        kitchenObject = null;
    }

    public bool HasKitchenObject() {
        return kitchenObject != null;
    }
}
