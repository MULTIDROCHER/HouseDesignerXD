using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(ParticleSystem))]
public class Explosion : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private float _lifeTime;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _lifeTime = _particleSystem.main.duration + _particleSystem.main.startLifetime.constantMax;
    }

    public void Start()
    {
        _particleSystem.Play();

        DOTween.Sequence()
                .AppendInterval(_lifeTime)
                .OnComplete(() =>
                {
                    Destroy(this.gameObject);
                });
    }
}