using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SaveControl : MonoBehaviour
{
    public Canvas popup;

    public Transform savesContainer;
    public Transform saveTemplate;
    public List<Transform> saveEntryTransformList;

    private List<SaveEntry> savesSE;

    public void AbrirPopup()
    {
        popup.enabled = true;
        this.BuscarDados();
    }

    public void FecharPopup()
    {
        popup.enabled = false;
    }

    public void CarregarJogo(int position)
    {
        Teste.saveGameAtual = savesSE[position].nomeArquivo;

        this.FecharPopup();

        new ChangeScene().TrocarCena("Jogo");
    }

    private void BuscarDados()
    {
        List<GameData> saves = SaveSystem.LoadGames();

        this.GerarTabela(this.Converter(saves));
    }

    private List<SaveEntry> Converter(List<GameData> saves)
    {
        savesSE = new List<SaveEntry>();

        foreach (var item in saves)
        {
            string data = DateTime.FromFileTime(item.saveTime).ToString("dd/MM/yyyy H:mm");

            savesSE.Add(new SaveEntry(data, item.nomeJogador, item.nomeArquivo));
        }

        return savesSE;
    }

    private void GerarTabela(List<SaveEntry> saveEntryList)
    {
        saveTemplate.gameObject.SetActive(false);

        foreach (var x in saveEntryTransformList)
        {
            Destroy(x.gameObject);
        }

        if (saveEntryList.Count > 0)
        {
            int i = 0;
            saveEntryTransformList = new List<Transform>();
            foreach (SaveEntry saveEntry in saveEntryList)
            {
                this.CreateRankingEntryTransform(i, saveEntry, savesContainer, saveEntryTransformList);
                i++;
            }
        }
    }

    private void CreateRankingEntryTransform(int position, SaveEntry saveEntry, Transform container, List<Transform> transformList)
    {
        float templateSpace = 35f;

        Transform entryTransform = Instantiate(saveTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, (-templateSpace * transformList.Count) - 15f);
        entryTransform.gameObject.SetActive(true);

        string data = saveEntry.data;
        entryTransform.Find("data").GetComponent<Text>().text = data;

        string nome = saveEntry.nome;
        entryTransform.Find("nome").GetComponent<Text>().text = nome;

        entryTransform.Find("iniciar").GetComponent<Button>().onClick.AddListener(delegate { CarregarJogo(position); });

        transformList.Add(entryTransform);
    }

}
