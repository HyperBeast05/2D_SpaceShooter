using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCreation : MonoBehaviour
{
    [SerializeField] int noOfLevels;
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Transform buttonParent;
    [SerializeField] List<Button> buttons;
    [SerializeField] Sprite unlockedSprite;
    [SerializeField] Sprite lockedSprite;

    [SerializeField] int firstLevelIndex;

    private void Awake()
    {
        for (int i = 0; i < noOfLevels; i++)
        {
            GameObject LevelBTN = Instantiate(buttonPrefab, buttonParent);
            LevelBTN.name = $"Level {i + 1}";
            string levelName = LevelBTN.name;
            LevelBTN.GetComponentInChildren<TextMeshProUGUI>().text = $"{i + 1}";
            Button button = LevelBTN.GetComponent<Button>();
            button.onClick.AddListener(()=> CanvasFader.instance.StartFadeOut(levelName));
            buttons.Add(button);
        }
    }
    void Start()
    {
        int nextLevel = PlayerPrefs.GetInt(EndGameManager.instance.lvlUnlock, firstLevelIndex);

        for (int i = 0; i < buttons.Count; i++)
        {
            if (i + firstLevelIndex <= nextLevel)
            {
                buttons[i].interactable = true;
                buttons[i].image.sprite = unlockedSprite;
            }
            else
            {
                buttons[i].interactable = false;
                buttons[i].image.sprite = lockedSprite;
                buttons[i].GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            }
        }
    }

    void Update()
    {

    }
}
