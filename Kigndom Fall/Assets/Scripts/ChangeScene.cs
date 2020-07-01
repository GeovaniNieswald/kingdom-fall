using UnityEngine.SceneManagement;

public class ChangeScene
{
    public void TrocarCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

}