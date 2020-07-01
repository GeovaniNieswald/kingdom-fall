using System;

[System.Serializable]
public class GameData
{
    public int idCharacter;
    public string nomeJogador;
    public float[] position;

    public long saveTime;

    public GameData(int idCharacter, string nomeJogador)
    {
        this.idCharacter = idCharacter;
        this.nomeJogador = nomeJogador;

        this.position = new float[3];
        position[0] = -39.71f;
        position[1] = -2.95f;
        position[2] = 17.47733f;

        this.saveTime = DateTime.Now.ToFileTime();
    }

}
