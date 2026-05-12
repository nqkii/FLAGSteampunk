using UnityEngine;

public class FootstepEvents : MonoBehaviour
{
    public AudioClip[] footstepClips;
    public AudioSource footstepSource;

    public void AnimationFootstep()
    {
        if (footstepClips.Length == 0 || footstepSource == null)
            return;

        AudioClip clip = footstepClips[Random.Range(0, footstepClips.Length)];
        footstepSource.pitch = Random.Range(0.95f, 1.05f);
        footstepSource.PlayOneShot(clip, 0.5f);
    }
}