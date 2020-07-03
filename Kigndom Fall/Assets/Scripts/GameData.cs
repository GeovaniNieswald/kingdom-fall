using System;

[System.Serializable]
public class GameData
{
    public int idCharacter;
    public string nomeJogador;
    public float[] position;
    public int pontuacao;
    public long saveTime;
    public string nomeArquivo;

    public GameData(int idCharacter, string nomeJogador)
    {
        this.idCharacter = idCharacter;
        this.nomeJogador = nomeJogador;

        this.position = new float[3];
        this.position[0] = -45.82751f;
        this.position[1] = 0.09500222f;
        this.position[2] = 17.47733f;

        this.pontuacao = 0;

        this.saveTime = DateTime.Now.ToFileTime();
    }

}
