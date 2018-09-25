using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ThunderEffect : MonoBehaviour
{
	public Text countText;
	public Text gameOverText;

	public float globalTimer = 122f;
	private float strikeTime = 0f;
	private float fadeTime = 0f;
	private SpriteRenderer sprite;
	public static bool mode = false;
	private bool spawn = true; //spawn once after game mode starts
	private int cloud = 1;

	private GameObject robot;
	public GameObject strikeParticle;

	public static int score;
	private int counter;
	public static float statistics = 0f;



	void Start() {
			sprite = GetComponent<SpriteRenderer> ();
			sprite.color = new Color (1f, 1f, 1f, 0f);
			robot = GameObject.FindWithTag ("Player");			
			score = 0;
			counter = -1;
			Result.initResult ();
			
	}

	void Update() {
		if (mode && spawn) {
			robot.transform.position = new Vector3 (-20.4f, 8.2f, 0f); //spawn point
			spawn = false;
		}
		if (mode) {

			globalTimer -= Time.deltaTime;
			strikeTime += Time.deltaTime;
			fadeTime += Time.deltaTime;

			//When it strikes, make thunder visible and check player's position to give him credit
			if (strikeTime > 2f) {
				sprite.color = new Color (1f, 1f, 1f, 1f);
				strikeTime = 0f;

				counter++;

				switch(cloud){
				case 1:
					if (robot.transform.position.x <= -13){					
						thunderSuccess();
					}
					break;
				case 2:
					if (robot.transform.position.x > -12 && robot.transform.position.x <= 0.8){
						thunderSuccess();
					}
					break;
				case 3:
					if (robot.transform.position.x > 0.8 && robot.transform.position.x <= 13.7){
						thunderSuccess();
					}
					break;
				case 4:
					if (robot.transform.position.x > 13.7){
						thunderSuccess();
					}
					break;
				}
			}

			//When thunder fades, move the thunder to the next cloud with a pattern of {1,3,2,4}
			//Fade time = 0.2 + strikeTime
			if (fadeTime > 2.2f) {		
				sprite.color = new Color (1f, 1f, 1f, 0f);
				fadeTime = strikeTime;

				switch(cloud){
					case 1:
						transform.position = new Vector3(7f, 3.05f, 0f);
						cloud = 3;
						break;
					case 2:
						transform.position = new Vector3(20, 3.05f, 0f);
						cloud = 4;
						break;
					case 3:
						transform.position = new Vector3(-6f, 3.05f, 0f);
						cloud = 2;
						break;
					case 4:
						transform.position = new Vector3(-19f, 3.05f, 0f);
						cloud = 1;
						break;
					}

			}
		
		}
		if (globalTimer <= 0) {
			statistics = 100*score/60;
			gameOverText.text = "Game Over";
			sprite.color = new Color (1f, 1f, 1f, 0f);
			globalTimer = 0;
			mode = false;
			StartCoroutine(coLoadLevel(2.5f));
		}
	}	

	void thunderSuccess()
	{
		score++;
		Result.setValue(counter);
		countText.text = "SCORE: " + score.ToString();
		strikeParticleEffect ();
	}


	IEnumerator coLoadLevel(float delay)
	{
		yield return new WaitForSeconds(delay);
		Application.LoadLevel("Scene_02");
	}

	void strikeParticleEffect()
	{
		Instantiate (strikeParticle, robot.transform.position, robot.transform.rotation);
	}
}
