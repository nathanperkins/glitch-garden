using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int loadDelay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadStart());
    }

    IEnumerator LoadStart() {
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene("StartScreen");
	}
}
