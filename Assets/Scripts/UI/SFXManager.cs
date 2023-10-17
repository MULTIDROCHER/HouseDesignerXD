using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXManager : MonoBehaviour
{
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private AudioClip _explosionSound;
    [SerializeField] private AudioClip _platingSound;

    private AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _source.PlayOneShot(_clickSound);
    }

    public void DoExplosion()
    {
        _source.PlayOneShot(_explosionSound);
    }

    public void CoverPlating()
    {
        _source.PlayOneShot(_platingSound);
    }
}