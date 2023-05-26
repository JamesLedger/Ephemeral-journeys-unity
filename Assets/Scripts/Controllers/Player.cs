using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

	#region Singleton

	public static Player instance;

	void Awake()
	{
		instance = this;
	}

	#endregion




	public CharacterStats playerStats;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
			int damageValue = collision.gameObject.GetComponent<OuchyProp>().damageValue;

			if (damageValue < 0)
			{
				playerStats.Heal(damageValue);
			}
			else if(damageValue > 0){
				playerStats.TakeDamage(damageValue, true);
			}
			

        }
    }

    void Die()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}