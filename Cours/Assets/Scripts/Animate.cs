using UnityEngine;

public class Animate : MonoBehaviour
{

    /// <summary>
    /// My Animator
    /// </summary>
    private Animator _animator;

	// Use this for initialization
    private void Start ()
    {
        _animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
    private void Update ()
    {
        float _forwardSpeed = Input.GetAxis("Vertical");
        float _turnSpeed = Input.GetAxis("Horizontal");
        //Pour que ça marche parfaitement, utilisez des courbes linéaires dans les animations
        //Faites attention aux majuscules, espaces etc.
        //La descélération est gérée directement par Unity
        //Oubliez pas que les GetAxis vont de -1 à 1
        _animator.SetFloat("Speed", _forwardSpeed);
        _animator.SetFloat("Turn", _turnSpeed);

    }
}
