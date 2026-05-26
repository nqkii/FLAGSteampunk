using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    public static CollectableManager instance;
    public int totalCollectables = 3;
    public float speedBoostAmount = 5f;
    public float speedBoostDuration = 5f;
    private int collected = 0;
    private bool boostActive = false;
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

        if (collected >= totalCollectables && !boostActive)
        {
            collected = 0;
            boostActive = true;
            playerMovement.ApplySpeedBoost(speedBoostAmount, speedBoostDuration);
            Invoke("ResetBoost", speedBoostDuration);
        }
    }

    void ResetBoost()
    {
        boostActive = false;
    }
}