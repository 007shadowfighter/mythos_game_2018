using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace TMPro
{
	public class CountdownTimer : MonoBehaviour
	{
		
		private TextMeshPro m_textMeshPro;
		private TMP_FontAsset m_FontAsset;
		private string label = "The <#0050FF>count is: </color>{0:2}";
		private float m_frame;
        public int endTime;
		private string timesup = "timesup"; //scene to go to when time is out


		void Start()
		{
            endTime = 25;
            // get new TextMesh Pro Component
            m_textMeshPro = gameObject.AddComponent<TextMeshPro>();

			m_textMeshPro.autoSizeTextContainer = true;

			// Load the Font Asset to be used.
			m_FontAsset = Resources.Load("Fonts & Materials/LiberationSans SDF", typeof(TMP_FontAsset)) as TMP_FontAsset;
			m_textMeshPro.font = m_FontAsset;

			// Assign Material to TextMesh Pro Component
			//m_textMeshPro.fontSharedMaterial = Resources.Load("Fonts & Materials/LiberationSans SDF - Bevel", typeof(Material)) as Material;
			//m_textMeshPro.fontSharedMaterial.EnableKeyword("BEVEL_ON");

			// Set various font settings.
			m_textMeshPro.fontSize = 15;
			m_textMeshPro.alignment = TextAlignmentOptions.Center;

			//m_textMeshPro.anchorDampening = true; // Has been deprecated but under consideration for re-implementation.
			//m_textMeshPro.enableAutoSizing = true;

			//m_textMeshPro.characterSpacing = 0.2f;
			//m_textMeshPro.wordSpacing = 0.1f;

			//m_textMeshPro.enableCulling = true;
			m_textMeshPro.enableWordWrapping = false; 
			m_textMeshPro.color = new Color32 (255, 255, 255, 255);
		}


		void Update()
		{
			
			m_frame += 1 * Time.deltaTime;
			var timeLeft = endTime - (int)Time.timeSinceLevelLoad;

            if (timeLeft < 31)
            {
                Debug.Log("Times up!");
                // make text red etc
                m_textMeshPro.color = new Color32(192, 192, 0, 255);
            }

            if (timeLeft < 11)
            {
                Debug.Log("Times up!");
                // make text red etc
                //m_textMeshPro.fontSize = 25;
                m_textMeshPro.color = new Color32(192, 0, 0, 255);
            }


			if (timeLeft < 0) 
			{
				timeLeft = 0;
				Debug.Log("Times up!");
				m_textMeshPro.SetText(label, timeLeft); //<<< show Time's UP!! on screen
                SceneManager.LoadScene(timesup);
                timeLeft = endTime;
            }
            label = timeLeft.ToString();
			m_textMeshPro.SetText(label, timeLeft);
            
        }

	}
}





//var endTime : float;
//var textMesh : TextMesh;
//
//
//function Start()
//{
//	endTime = Time.time + 60;
//	textMesh = GameObject.Find ("Timer").GetComponent(TextMesh);
//	textMesh.text = "60";
//}
//
//
//function Update()
//{
//	var timeLeft : int = endTime - Time.time;
//	if (timeLeft < 0) timeLeft = 0;
//	textMesh.text = timeLeft.ToString();
//}
