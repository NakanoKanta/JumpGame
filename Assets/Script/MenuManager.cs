using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject C_Menu;
    [SerializeField] GameObject Title;

    [SerializeField] AudioSource audioSource;   // å¯â âπçƒê∂óp
    [SerializeField] AudioClip clickSound;      // çƒê∂Ç∑ÇÈå¯â âπ

    void Start()
    {
        Menu.SetActive(true);
        C_Menu.SetActive(false);
        Title.SetActive(false);
    }

    public void GoMenu()
    {
        StartCoroutine(PlaySoundThen(() =>
        {
            Menu.SetActive(false);
            C_Menu.SetActive(true);
            Title.SetActive(true);
        }));
    }

    public void CloseMenu()
    {
        StartCoroutine(PlaySoundThen(() =>
        {
            Menu.SetActive(true);
            C_Menu.SetActive(false);
            Title.SetActive(false);
        }));
    }
    private IEnumerator PlaySoundThen(System.Action action)
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
            yield return new WaitForSeconds(clickSound.length);
        }

        action?.Invoke();  // âπÇ™èIÇÌÇ¡ÇΩå„Ç…é¿çs
    }
}
