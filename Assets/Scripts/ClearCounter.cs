using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;

    
    public void Interact() {
        Debug.Log("Interact");
        Transform kitchenObjectTransfrom =  Instantiate(kitchenObjectSO.prefab, counterTopPoint);
        kitchenObjectTransfrom.localPosition = Vector3.zero;

        Debug.Log(kitchenObjectTransfrom.GetComponent<KitchenObject>().GetKitchenObjectSO().objectName);
    }
}
