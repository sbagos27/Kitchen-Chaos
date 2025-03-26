using System;
using UnityEngine;

public class PlatesCounter : BaseCounter {
    
    
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;

    [SerializeField] private KitchenObjectSO plateKicthenObjectSO;
    
    private float spawnPlateTimer;
    private float spawnPlateTimerMax = 4f;
    private int platesSpawnedAmount;
    private int platesSpawnedAmountMax = 4;


    private void Update() {
        spawnPlateTimer += Time.deltaTime;
        if (spawnPlateTimer > spawnPlateTimerMax) {
            spawnPlateTimer = 0f;
            if (platesSpawnedAmount < platesSpawnedAmountMax) {
                platesSpawnedAmount++;
                OnPlateSpawned?.Invoke(this, new EventArgs());
            }
        }
    }

    public override void Interact(Player player) {
        if (!player.HasKitchenObject()) {
            //player is holding nothing
            if (platesSpawnedAmount > 0) {
                //atleast a plate
                platesSpawnedAmount--;
                
                KitchenObject.SpawnKitchenObject(plateKicthenObjectSO, player);
                OnPlateRemoved?.Invoke(this, new EventArgs());
            }
        }
    }
}
