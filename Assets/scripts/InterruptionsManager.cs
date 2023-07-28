using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterruptionsManager : MonoBehaviour
{
    [Header("Interruption Management")]
    [SerializeField]
    private float deltaTimeInterruption = 7;
    [SerializeField]
    private float InterruptionTime = 1;
    [SerializeField]
    private float randomRangeTime = 3;

    [Header("Text")]
    [SerializeField]
    private GameObject InterruptionObject;
    [SerializeField]
    private List<Sprite> InterruptionImages;

    private float time;
    private float timer;

    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GetComponent<GameManager>();
        if (InterruptionImages.Count == 0)
        {
            Debug.Log("No Images for interruptionList in InterruptionManager");
        }
        timer = 0;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gm.hasWon)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                HidePopup();
                time += Time.deltaTime;
            }

            if (time > deltaTimeInterruption + Random.value * randomRangeTime)
            {
                ShowPopup();
                time = 0;
            }
        }
    }

    void ShowPopup()
    {
        InterruptionObject.GetComponent<Image>().sprite = InterruptionImages[Random.Range(0, InterruptionImages.Count)];
        //currentImage = InterruptionObjects[Random.Range(0, InterruptionImages.Count)];
        InterruptionObject.SetActive(true);
        timer = InterruptionTime;
    }

    void HidePopup()
    {
        InterruptionObject.SetActive(false);
    }
}
