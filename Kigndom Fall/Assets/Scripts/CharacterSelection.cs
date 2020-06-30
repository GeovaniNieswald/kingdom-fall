using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class CharacterSelection : MonoBehaviour
{
    private int selectedCharacterIndex = 0;

    [Header("List of characters")]
    [SerializeField] private List<CharacterSelectObject> characterList = new List<CharacterSelectObject>();

    [Header("UI References")]
    [SerializeField] private Transform personagemTransform;
    [SerializeField] private SpriteRenderer personagemSprite;
    [SerializeField] private Animator personagemAnimator;
    [SerializeField] private TextMeshProUGUI nomePersonagem;

    private void Start()
    {
        UpdateCharacterSelectionUI();
    }

    public void LeftArrow()
    {
        selectedCharacterIndex--;
        if (selectedCharacterIndex < 0)
        {
            selectedCharacterIndex = characterList.Count - 1;
        }

        UpdateCharacterSelectionUI();
    }

    public void RightArrow()
    {
        selectedCharacterIndex++;
        if (selectedCharacterIndex == characterList.Count)
        {
            selectedCharacterIndex = 0;
        }

        UpdateCharacterSelectionUI();
    }

    private void UpdateCharacterSelectionUI()
    {
        personagemSprite.sprite = characterList[selectedCharacterIndex].spritePers;
        personagemAnimator.runtimeAnimatorController = characterList[selectedCharacterIndex].animatorPers;
        nomePersonagem.text = characterList[selectedCharacterIndex].nomePers;

        personagemTransform.localPosition = new Vector3(characterList[selectedCharacterIndex].x, characterList[selectedCharacterIndex].y, characterList[selectedCharacterIndex].z);
        personagemTransform.localScale = new Vector3(characterList[selectedCharacterIndex].scaleX, characterList[selectedCharacterIndex].scaleY, 250);
    }

    [System.Serializable]
    public class CharacterSelectObject
    {
        public float x;
        public float y;
        public float scaleX;
        public float scaleY;
        public float z;
        public Sprite spritePers;
        public RuntimeAnimatorController animatorPers;
        public string nomePers;
    }
}
