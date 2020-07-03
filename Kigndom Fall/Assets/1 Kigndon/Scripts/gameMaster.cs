using UnityEngine;
using TMPro;

public class gameMaster : MonoBehaviour
{

    public int points;

    public TextMeshProUGUI pointsText;

    void Update()
    {
        pointsText.text = "Pontos: " + points;
        Teste.pontuacaoAtual = points;
    }
}

