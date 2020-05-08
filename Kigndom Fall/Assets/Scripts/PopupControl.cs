using UnityEngine;

public class PopupControl : MonoBehaviour
{
    public Canvas popup;
    public SpriteRenderer spriteRenderer;

    public void AbrirPopup()
    {
        popup.enabled = true;

        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = true;
        }
    }

    public void FecharPopup()
    {
        popup.enabled = false;

        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
    }

}
