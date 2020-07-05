using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class CharacterSelection : MonoBehaviour
{
    public Canvas popup;
    public Canvas popupErro;
    public SpriteRenderer spriteRenderer;
    public TMP_InputField nomeJogador;

    private int selectedCharacterIndex;

    [Header("List of Characters")]
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

    public void Iniciar()
    {
        string nomeJogadorStr = this.nomeJogador.text;

        if (nomeJogadorStr.Length == 0)
        {
            popupErro.enabled = true;
        }
        else
        {
            GameData gd = new GameData(this.selectedCharacterIndex, nomeJogadorStr);

            DadosGlobais.saveGameAtual = SaveSystem.SaveNewGame(gd);

            this.FecharPopup();

            new ChangeScene().TrocarCena("Jogo");
        }
    }

    private void UpdateCharacterSelectionUI()
    {
        personagemSprite.sprite = characterList[selectedCharacterIndex].spritePers;
        personagemAnimator.runtimeAnimatorController = characterList[selectedCharacterIndex].animatorPers;
        nomePersonagem.text = characterList[selectedCharacterIndex].nomePers;

        personagemTransform.localPosition = new Vector3(characterList[selectedCharacterIndex].x, characterList[selectedCharacterIndex].y, characterList[selectedCharacterIndex].z);
        personagemTransform.localScale = new Vector3(characterList[selectedCharacterIndex].scaleX, characterList[selectedCharacterIndex].scaleY, 250);
    }

    private void FecharPopup()
    {
        popup.enabled = false;

        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
    }

    [System.Serializable]
    public class CharacterSelectObject
    {
        public float x;
        public float y;
        public float z;
        public float scaleX;
        public float scaleY;
        public Sprite spritePers;
        public RuntimeAnimatorController animatorPers;
        public string nomePers;
    }

}
