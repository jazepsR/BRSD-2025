using PurrNet;
using TMPro;
using UnityEngine;

public class PlayerNumber : NetworkBehaviour
{
    public SyncVar<int> playerNumber = new(0, ownerAuth: true);
    public TMP_Text numberText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        numberText.text = playerNumber.ToString();
        playerNumber.onChanged += OnNumberChange;
    }
    void OnDisable()
    {
        playerNumber.onChanged -= OnNumberChange;
    }

    private void OnNumberChange(int obj)
    {
        numberText.text = obj.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            playerNumber.value++;
        } if (Input.GetKeyDown(KeyCode.R))
        {
            playerNumber.value--;
        }
    }
}
