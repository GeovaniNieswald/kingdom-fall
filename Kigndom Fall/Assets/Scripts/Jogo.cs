using UnityEngine;

public class Jogo : MonoBehaviour
{
    public Transform personagem;

    void Start()
    {
        GameData gd = SaveSystem.LoadGame(Teste.saveGameAtual);

        Debug.Log(gd.position[0]);
        Debug.Log(gd.position[1]);
        Debug.Log(gd.position[2]);

        Vector3 posicaoJogador;
        posicaoJogador.x = gd.position[0];
        posicaoJogador.y = gd.position[1];
        posicaoJogador.z = gd.position[2];

        this.personagem.localPosition = posicaoJogador;
    }

}
