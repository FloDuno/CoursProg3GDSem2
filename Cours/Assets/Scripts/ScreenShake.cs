using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour {

    /// <summary>
    /// Courbe d'animation à modifier dans l'inspector
    /// </summary>
    [SerializeField] private AnimationCurve _curve;

    [SerializeField] private GameObject _prefab;

	// Update is called once per frame
    private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LaunchAnim());
            //	        Spawn();
        }
    }

    /// <summary>
    /// Utilisée pour montrer comment fonctionne le profiler
    /// </summary>
    private void Spawn()
    {
        for (int i = 0; i < 500; i++)
        {
            Instantiate(_prefab);
        }
    }

    /// <summary>
    /// Coroutine gérant une animation selon le temps passé et une courbe d'animation
    /// Ce qui est avant le while est exécuté au lancement, ce qui est après à la fin et dedans c'est à chaque frame
    /// </summary>
    /// <returns></returns>
    private IEnumerator LaunchAnim()
    {
        //Temps écoulé depuis le lancement
        float _actualTime = 0;
        //Tant que le temps n'a pas dépassé le temps de la courbe
        while (_actualTime < _curve.keys[_curve.length-1].time) //_curve.keys[_curve.length - 1] = le dernier point de la courbe. On récupère donc son timecode (valeur en X)
        {
            //On compte le temps passé en ajoutant le temps écoulé depuis la dernière frame
            _actualTime += Time.deltaTime;
            //On fait varier le y de la position selon la courbe
            transform.position = new Vector3(0,_curve.Evaluate(_actualTime),0);//Evaluate prend en paramètre la valeur en x et renvoie la valeur en y de la courbe d'animation
            //Permet de passer à la frame suivante
            yield return null;
        }
        //Test pour montrer qu'on peux exécuter une instruction à la fin de la coroutine
        print("tsreirsu");
    }
}
