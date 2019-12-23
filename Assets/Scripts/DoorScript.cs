using UnityEngine;
using UnityEngine.Serialization;

public class DoorScript : MonoBehaviour
{
    public bool CanOpen = false;

    [FormerlySerializedAs("SoundOpen")] [SerializeField] private AudioClip soundOpen;
    [FormerlySerializedAs("SoundDenied")] [SerializeField] private AudioClip soundDenied;
    
    [FormerlySerializedAs("AfterBurner")] [SerializeField] private GameObject afterBurner;

    private AudioSource _myAudioSource;
    private bool _isOpen = false;
    private GameObject _door;

    private void Awake()
    {
        _myAudioSource = GetComponent<AudioSource>();
        _door = GameObject.Find("Door");
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something want to enter " + other.tag);
        if (!_isOpen)
        {
            if (other.CompareTag("Player") && CanOpen)
            {
                _isOpen = true;
                _door.GetComponent<Animator>().enabled = true;
                afterBurner.SetActive(true);
                _myAudioSource.PlayOneShot(soundOpen);
            }
            else
            {
                _myAudioSource.PlayOneShot(soundDenied);
            }
        }
    }
}
