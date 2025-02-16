using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryController : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject dropButton;
    public GameObject patrollingPrefab;
    public GameObject patrollingChildItem;

    public List<AccessoryScriptableObject> eyePrefabs;

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

    public void SelectRandomCurrentItem()
    {
        dropButton.SetActive(true);
        patrollingPrefab.SetActive(true);
        currentDropItem = eyePrefabs[ChooseRandomEye()];
        //currentDropItem = accessory;

        patrollingItemImage.sprite = currentDropItem.accessorySprite;
    }

    private int ChooseRandomEye()
    {
        int rnd = Random.Range(0, eyePrefabs.Count);
        return rnd;
    }

    public void DropAccessory()
    {
        var positionAtDrop = patrollingChildItem.GetComponent<Transform>().position;
        dropButton.SetActive(false);
        patrollingPrefab.SetActive(false);

        var droppedAccessory = Instantiate(currentDropItem.prefab);
        droppedAccessory.transform.position = positionAtDrop;

        var rb = droppedAccessory.GetComponentInChildren<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.velocity = new Vector2(0, -5f);
    }

}
