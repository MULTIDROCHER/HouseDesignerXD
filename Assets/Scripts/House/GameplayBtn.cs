using UnityEngine;
using UnityEngine.UI;

public class GameplayBtn : MonoBehaviour
{
    [SerializeField] private ResetHouseBtn _resetBtn;

    public void Replay()
    {
        _resetBtn.ClearAllFurniture();
        _resetBtn.ClearAllPlatings();

        CarcassPart[] _carcass = FindObjectsOfType<CarcassPart>();

        foreach (var part in _carcass)
        {
            part.GetComponent<Image>().color = Color.white;
        }
    }

    public void FinishBuilding()
    {
        MainProgram program = FindObjectOfType<MainProgram>();
        ItemContainer items = FindObjectOfType<ItemContainer>();

        items.transform.SetParent(program.transform);

        SceneLoader.LoadScene(2);
    }
}