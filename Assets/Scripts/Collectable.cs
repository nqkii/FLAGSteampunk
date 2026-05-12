using UnityEngine;

public class Collectable : MonoBehaviour
{
    public AudioClip pickupSound;
    public GameObject collectEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CollectableManager.instance.CollectItem();

            if (collectEffect != null)
            {
                GameObject effect = Instantiate(collectEffect, transform.position, Quaternion.identity);
                Destroy(effect, 2f);
            }

            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            Destroy(gameObject);
        }
    }
}