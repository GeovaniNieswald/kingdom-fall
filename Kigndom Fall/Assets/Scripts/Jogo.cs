using UnityEngine;
using System.Collections.Generic;

public class Jogo : MonoBehaviour
{
    [Header("List of Characters")]
    [SerializeField] private List<Character> characterList = new List<Character>();

    [Header("UI References")]
    [SerializeField] public Transform personagemTrans;
    [SerializeField] public SpriteRenderer personagemSpri;
    [SerializeField] public Animator personagemAni;
    [SerializeField] public CircleCollider2D personagemCircleCollider2D;
    [SerializeField] public BoxCollider2D personagemBoxCollider2D;

    void Start()
    {
        GameData gd = SaveSystem.LoadGame(Teste.saveGameAtual);

        int idCharacter = gd.idCharacter;

        Vector3 posicaoJogador;
        posicaoJogador.x = gd.position[0];
        posicaoJogador.y = gd.position[1];
        posicaoJogador.z = gd.position[2];

        Vector3 scaleJodador;
        scaleJodador.x = characterList[idCharacter].scale;
        scaleJodador.y = characterList[idCharacter].scale;
        scaleJodador.z = characterList[idCharacter].scale;

        Vector2 offsetCircleCollider;
        offsetCircleCollider.x = characterList[idCharacter].circleColliderX;
        offsetCircleCollider.y = characterList[idCharacter].circleColliderY;

        Vector2 offsetBoxCollider;
        offsetBoxCollider.x = characterList[idCharacter].boxColliderX;
        offsetBoxCollider.y = characterList[idCharacter].boxColliderY;

        Vector2 sizeBoxCollider;
        sizeBoxCollider.x = characterList[idCharacter].boxColliderSizeX;
        sizeBoxCollider.y = characterList[idCharacter].boxColliderSizeY;

        this.personagemTrans.localPosition = posicaoJogador;
        this.personagemTrans.localScale = scaleJodador;

        this.personagemSpri.sprite = characterList[idCharacter].spritePers;
        this.personagemAni.runtimeAnimatorController = characterList[idCharacter].animatorPers;

        this.personagemCircleCollider2D.offset = offsetCircleCollider;
        this.personagemCircleCollider2D.radius = characterList[idCharacter].circleColliderRadius;

        this.personagemBoxCollider2D.offset = offsetBoxCollider;
        this.personagemBoxCollider2D.size = sizeBoxCollider;
    }

    [System.Serializable]
    public class Character
    {
        public Sprite spritePers;
        public RuntimeAnimatorController animatorPers;

        public float scale;

        public float circleColliderX;
        public float circleColliderY;
        public float circleColliderRadius;

        public float boxColliderX;
        public float boxColliderY;

        public float boxColliderSizeX;
        public float boxColliderSizeY;
    }

}
