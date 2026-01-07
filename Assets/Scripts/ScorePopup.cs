using UnityEngine;
using TMPro;

public class ScorePopup : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;
    private Vector3 moveVector;

    private const float DISAPPEAR_TIMER_MAX = 1f; // temps du texte

    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }
    
    public void Setup(int scoreAmount, Color color)
    {
        textMesh.text = "+" + scoreAmount.ToString();
        
        // couleur
        textMesh.color = color;
        textColor = color; 
        
        //mouvement
        disappearTimer = DISAPPEAR_TIMER_MAX;
        moveVector = new Vector3(0, 1, 0); 
    }

    private void Update()
    {
        transform.position += moveVector * Time.deltaTime;
        moveVector -=  2f * Time.deltaTime * moveVector;

        // disparition
        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            // fade out
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;

            // opti pour la memoire
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}