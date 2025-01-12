using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryController : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject dropButton;
    public GameObject patrollingPrefab;
    public GameObject patrollingChildItem;


    private SpriteRenderer patrollingItemImage;

    public AccessoryScriptableObject currentDropItem { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        patrollingPrefab.SetActive(false);
        patrollingItemImage = patrollingPrefab.GetComponentInChildren<SpriteRenderer>();
    }

    public void SelectCurrentItem(AccessoryScriptableObject accessory)
    {
        dropButton.SetActive(true);
        patrollingPrefab.SetActive(true);
        currentDropItem = accessory;

        patrollingItemImage.sprite = currentDropItem.accessorySprite;
    }

    public void DropAccessory()
    {
        var positionAtDrop = patrollingChildItem.GetComponent<Transform>().position;
        dropButton.SetActive(true);
        patrollingPrefab.SetActive(true);

        var droppedAccessory = Instantiate(currentDropItem.prefab);
        droppedAccessory.transform.position = positionAtDrop;

        var rb = droppedAccessory.GetComponentInChildren<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints2D.None;
    }
}
