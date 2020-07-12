using UnityEngine;

// Ensures an audio component is always attached along with the script
[RequireComponent(typeof(AudioSource))]
public class BackgroundThemeHandler : MonoBehaviour {

    // Ref to audiosource component
    private AudioSource src;

	// Use this for initialization
	void Start () {
        // Access audio source, set attribs and play
        src = GetComponent<AudioSource>();
        src.loop = true;
        src.volume = 0.1f;
        src.Play();
	}
}
