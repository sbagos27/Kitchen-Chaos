using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    public Transform playerTransform;
    public Camera cam;
    public NavMeshAgent player;
    public Animator playerAnimator;
    public GameObject targetDest;
    public CinemachineInputAxisController cinemachineInputAxisController;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;

            if (Physics.Raycast(ray, out hitPoint)) {
                targetDest.transform.position = hitPoint.point;
                player.SetDestination(hitPoint.point);
            }
        }

        if (Input.GetMouseButtonDown(1)) {
            player.ResetPath();
        }

        if (Input.GetMouseButtonDown(2)) {
            cinemachineInputAxisController.enabled = true;
            Debug.Log("CinemachineInputAxisController");
        }

        if (Input.GetMouseButtonUp(2)) {
            cinemachineInputAxisController.enabled = false;
        }
        
        if (player.velocity != Vector3.zero)
        {
            playerAnimator.SetBool("IsWalking", true);

        }
        else if (player.velocity == Vector3.zero)
        {
            playerAnimator.SetBool("IsWalking", false);
        }
    }

    
}