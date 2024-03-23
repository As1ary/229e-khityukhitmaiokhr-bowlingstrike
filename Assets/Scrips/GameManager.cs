using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject bowlingPrefab;

    [SerializeField] private GameObject bowlingPositions;

    [SerializeField] private GameObject pinsPrefab;

    [SerializeField] private GameObject[] pinsPositions;

    public static GameManager instance;

    void Start()
    {
        instance = this;
        SetPins(1);
        SetPins(2);
        SetPins(3);
        SetPins(4);
        SetPins(5);
        SetPins(6);
        SetPins(7);
        SetPins(8);
        SetPins(9);
        SetPins(0);
        SetBowling();
    }
    private void SetPins(int i )
    {
        GameObject obj = Instantiate(pinsPrefab,pinsPositions[i].transform.position,Quaternion.identity);
    }

    private void SetBowling()
    {
        GameObject obj = Instantiate(bowlingPrefab,bowlingPositions.transform.position,Quaternion.identity);
    }
}
