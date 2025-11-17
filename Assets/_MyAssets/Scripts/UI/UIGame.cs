using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIGame : MonoBehaviour
{
    private Player _player;

    //Définir singleton ---------------------------------------------
    public static UIGame Instance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //---------------------------------------------------------------

    private void Start()
    {
	_player = FindAnyObjectByType<Player>();
    }


    [SerializeField] private TMP_Text _txtCollisions = default(TMP_Text);
    [SerializeField] private TMP_Text _txtTemps = default(TMP_Text);

    // Public

    public void ChangerTemps()
    {
	_txtTemps.text = "Temps : " + (Time.time - _player.GetTempsDepart()).ToString("f2") + "S";
    }
    public void ChangerCollisions()
    {
	_txtCollisions.text = "Collisions : " + GestionJeu.Instance.Pointage;
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
        GestionJeu.Instance.TogglePause();
        SceneManager.LoadScene(0);
        
    }
}
