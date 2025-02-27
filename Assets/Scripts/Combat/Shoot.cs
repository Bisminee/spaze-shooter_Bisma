using UnityEngine;


public class Shoot: MonoBehaviour{

    public GameObject [] weapon;
    public GameObject bulletPrefab;
    private PlayerInput playerInput;

    private void Start() {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update() {
        if (bulletPrefab != null && playerInput.Shoot)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            Debug.Log("Trigger is pulled");
        }
    }
}