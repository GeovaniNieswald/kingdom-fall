using UnityEngine;

public class GameOverControl : MonoBehaviour
{
    public Canvas gameOver;
    public Transform pers;

    private bool perdeu = false;

    void Update()
    {
        if (gameOver.enabled)
        {
            if (!perdeu)
            {
                Destroy(pers.gameObject);
                perdeu = true;
            }

            if (Input.GetButton("Jump"))
            {
                new ChangeScene().TrocarCena("Jogo");
            }
        }
    }

}
