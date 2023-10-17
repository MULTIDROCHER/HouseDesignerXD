using UnityEngine;

[RequireComponent(typeof(Item))]
public class ItemDestroyer : MonoBehaviour
{
    [SerializeField] private Explosion _explosion;

    private Item _item;

    private void Awake()
    {
        _item = GetComponent<Item>();
    }

    private void OnEnable()
    {
        _item.DestroyItem += OnItemDestroy;
    }

    private void OnDisable()
    {
        _item.DestroyItem -= OnItemDestroy;
    }

    public void DestroyItem(Item item)
    {
        OnItemDestroy(item);
    }

    private void OnItemDestroy(Item item)
    {
        if (_explosion != null)
        {
            Instantiate(_explosion, item.transform.position, Quaternion.identity);
            SFXManager _sfx = FindObjectOfType<SFXManager>();

            if (_sfx != null)
                _sfx.DoExplosion();
        }

        Destroy(item.gameObject);
    }
}