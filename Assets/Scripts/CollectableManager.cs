using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    public static CollectableManager instance;

    public int totalCollectables = 3;
    public float speedBoostAmount = 5f;
    public float speedBoostDuration = 5f;

    private int collected = 0;
    private PlayerMovement playerMovement;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public void CollectItem()
    {
        collected++;
        Debug.Log("Collected: " + collected + "/" + totalCollectables);

        if (collected == totalCollectables)
        {
            playerMovement.ApplySpeedBoost(speedBoostAmount, speedBoostDuration);
            totalCollectables = 0;
        }
    }
}