using System;
using System.Collections;
using UnityEngine;

public class BumperVisuals : MonoBehaviour
{
    Color32 originalColor;
    Vector3 originalScale;
    private Renderer objectRenderer;
    // intensite HDR
    [SerializeField] private float hdrIntensity = 3.5f; 

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
        originalScale = transform.localScale;
        
        //active emission pour HDR
        objectRenderer.material.EnableKeyword("_EMISSION");
    }
    
    public void ActiverAnimation()
    {
        //stop la coroutine pour eviter qu'il y en ait plusieurs
        StopAllCoroutines(); 
        StartCoroutine(SwapColorAndScale());
    }

    public IEnumerator SwapColorAndScale()
    {
        //changement couleur
        Color32 current32 = originalColor;
        byte r = (byte)Mathf.Clamp(current32.r + 20, 0, 255);
        byte g = (byte)Mathf.Clamp(current32.g - 50, 0, 255);
        byte b = (byte)Mathf.Clamp(current32.b - 50, 0, 255);
        
        Color targetColor = new Color32(r, g, b, current32.a);
        
        //target couleur + intensité du HDR
        Color targetHDR = targetColor * hdrIntensity; 

        //target des scale
        Vector3 targetBig = new Vector3(originalScale.x, originalScale.y * 1.5f, originalScale.z);
        Vector3 targetSmall = new Vector3(originalScale.x, originalScale.y * 0.9f, originalScale.z);

        
        float duration = 0.1f; 
        for (float t = 0; t < 1f; t += Time.deltaTime / duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetBig, t);
            //couleur + hdr
            objectRenderer.material.color = Color.Lerp(originalColor, targetColor, t);
            objectRenderer.material.SetColor("_EmissionColor", Color.Lerp(Color.black, targetHDR, t));
            yield return null;
        }
        transform.localScale = targetBig;
        objectRenderer.material.color = targetColor;
        objectRenderer.material.SetColor("_EmissionColor", targetHDR);
        
        
        duration = 0.2f; 
        for (float t = 0; t < 1f; t += Time.deltaTime / duration)
        {
            transform.localScale = Vector3.Lerp(targetBig, targetSmall, t);
            yield return null;
        }
        transform.localScale = targetSmall;
        
        
        duration = 0.2f;
        for (float t = 0; t < 1f; t += Time.deltaTime / duration)
        {
            //retour scale originale
            transform.localScale = Vector3.Lerp(targetSmall, originalScale, t);
            //couleur + hdr original
            objectRenderer.material.color = Color.Lerp(targetColor, originalColor, t);
            objectRenderer.material.SetColor("_EmissionColor", Color.Lerp(targetHDR, Color.black, t));
            yield return null;
        }
        
        //retour scale et couleur d'origine
        objectRenderer.material.color = originalColor;
        objectRenderer.material.SetColor("_EmissionColor", Color.black);
        transform.localScale = originalScale;
    }
}