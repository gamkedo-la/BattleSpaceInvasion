using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LivesUI : MonoBehaviour
{
    public GameObject playerGameObject;

    private Text livesText;
    // Start is called before the first frame update
    void Start()
    {
        livesText = GetComponent<Text>();
        Player player = playerGameObject.GetComponent<Player>();
        PlayerLivesChanged(player.GetPlayerLives());
        player.playerLivesChanged += PlayerLivesChanged;
    }

    private void PlayerLivesChanged(int newLivesValue)
    {
        livesText.text = "Lives: " + newLivesValue.ToString();
    }
}
