using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using TMPro;

public class UIFin : MonoBehaviour
{

    [SerializeField] private TMP_Text _txtTemps = default(TMP_Text);
    [SerializeField] private TMP_Text _txtCollisions = default(TMP_Text);
    [SerializeField] private TMP_Text _txtFinal = default(TMP_Text);
    private Player _player;
    private GestionJeu gestionJeu;
    

    private void Awake()
    {
        // Vérifie s'il existe un GameManager si oui on le détruit
        GestionJeu gestionJeu = FindAnyObjectByType<GestionJeu>();
        UIGame uiGame = FindAnyObjectByType<UIGame>();


        if (uiGame != null)
        {
            Destroy(uiGame.gameObject);
        }
    }
    private void Start()
    {
	_player = FindAnyObjectByType<Player>();

        _txtTemps.text = "Temps total : " + GestionJeu.Instance.ListeTemps.Sum().ToString("f2") + " S";
        _txtCollisions.text = "Collisions : " + GestionJeu.Instance.Pointage.ToString();
        float totalFinal = GestionJeu.Instance.ListeTemps.Sum() + GestionJeu.Instance.ListeAccrochages.Sum();
        _txtFinal.text = "Pointage final : " + totalFinal.ToString("f2");
    }

    public void OnQuitterClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnRecommencerClick()
    {
        SceneManager.LoadScene(0);
	if (gestionJeu != null) 
        {
            Destroy(gestionJeu.gameObject);
        }
    }
}
