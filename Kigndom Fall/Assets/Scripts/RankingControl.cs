using UnityEngine;
using Firebase.Database;
using System.Collections.Generic;
using UnityEngine.UI;
using Utils.UtilsClass;

public class RankingControl : MonoBehaviour
{
    public Canvas popup;

    public Transform rankingContainer;
    public Transform rankingTemplate;
    private List<Transform> rankingEntryTransformList;

    public void AbrirPopup()
    {
        popup.enabled = true;
        this.BuscarDados();
    }

    public void FecharPopup()
    {
        popup.enabled = false;
    }

    private void BuscarDados()
    {
        FirebaseDatabase.DefaultInstance
            .GetReference("pontuacoes")
            .GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.LogError("Erro");
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;

                    List<RankingEntry> pontuacoes = new List<RankingEntry>();

                    foreach (DataSnapshot ds in snapshot.Children)
                    {
                        RankingEntry re = JsonUtility.FromJson<RankingEntry>(ds.GetRawJsonValue());
                        pontuacoes.Add(re);
                    }

                    this.GerarTabela(pontuacoes);
                }
            });
    }

    private void GerarTabela(List<RankingEntry> rankingEntryList)
    {
        rankingTemplate.gameObject.SetActive(false);

        if (rankingEntryList.Count > 0)
        {
            for (int i = 0; i < rankingEntryList.Count; i++)
            {
                for (int j = i + 1; j < rankingEntryList.Count; j++)
                {
                    if (rankingEntryList[j].pontuacao > rankingEntryList[i].pontuacao)
                    {
                        // Swap
                        RankingEntry tmp = rankingEntryList[i];
                        rankingEntryList[i] = rankingEntryList[j];
                        rankingEntryList[j] = tmp;
                    }
                }
            }

            rankingEntryTransformList = new List<Transform>();
            foreach (RankingEntry rankingEntry in rankingEntryList)
            {
                CreateRankingEntryTransform(rankingEntry, rankingContainer, rankingEntryTransformList);
            }
        }
    }

    private void CreateRankingEntryTransform(RankingEntry rankingEntry, Transform container, List<Transform> transformList)
    {
        float templateSpace = 35f;

        Transform entryTransform = Instantiate(rankingTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, (-templateSpace * transformList.Count) - 15f);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString = rank + "º";
        entryTransform.Find("pos").GetComponent<Text>().text = rankString;

        int pontuacao = rankingEntry.pontuacao;
        entryTransform.Find("pontos").GetComponent<Text>().text = pontuacao.ToString();

        string nome = rankingEntry.nome;
        entryTransform.Find("nome").GetComponent<Text>().text = nome;

        if (rank == 1)
        {
            entryTransform.Find("pos").GetComponent<Text>().color = Color.green;
            entryTransform.Find("pontos").GetComponent<Text>().color = Color.green;
            entryTransform.Find("nome").GetComponent<Text>().color = Color.green;
        }

        switch (rank)
        {
            case 1:
                entryTransform.Find("estrela").GetComponent<Image>().color = UtilsClass.GetColorFromString("EAE206");
                break;
            case 2:
                entryTransform.Find("estrela").GetComponent<Image>().color = UtilsClass.GetColorFromString("A7AB9A");
                break;
            case 3:
                entryTransform.Find("estrela").GetComponent<Image>().color = UtilsClass.GetColorFromString("A97339");
                break;
            default:
                entryTransform.Find("estrela").gameObject.SetActive(false);
                break;
        }

        transformList.Add(entryTransform);
    }

}
