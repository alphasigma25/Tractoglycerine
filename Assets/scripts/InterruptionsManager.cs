using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptionsManager : MonoBehaviour
{
    [Header("Interruption Management")]
    [SerializeField]
    private float deltaTimeInterruption = 7;
    [SerializeField]
    private float InterruptionTime = 1;
    [SerializeField]
    private float chanceOfInterruption = 0.1f;

    [Header("Text")]
    [SerializeField]
    private List<GameObject> InterruptionImages;

    private GameObject currentImage;

    private float time;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        if (InterruptionImages.Count == 0)
        {
            Debug.Log("No Images for interruptionList in InterruptionManager");
        }
        timer = 0;
        time = 0;
        currentImage = InterruptionImages[0];
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            HidePopup();
        }

        time += Time.deltaTime;
        if (time > deltaTimeInterruption && Random.value > chanceOfInterruption)
        {
            ShowPopup();
            time = 0;
        }
    }

    void ShowPopup()
    {
        currentImage = InterruptionImages[Random.Range(0, InterruptionImages.Count)];
        currentImage.SetActive(true);
        timer = InterruptionTime;
    }

    void HidePopup()
    {
        currentImage.SetActive(false);
    }
}
