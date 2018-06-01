using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GuiStartMenu : MonoBehaviour {
	
	void OnEnable(){	
		EasyTouch.On_SimpleTap += On_SimpleTap;
	}
	
	void OnGUI() {
	            
		GUI.matrix = Matrix4x4.Scale( new Vector3( Screen.width / 1024.0f, Screen.height / 768.0f, 1 ) );
		
		GUI.Box( new Rect( 0, -4, 1024, 70 ), "" );
		
	}
	
	void On_SimpleTap( Gesture gesture){
	
		if ( gesture.pickObject!=null){
			string levelName= gesture.pickObject.name;
            
			if (levelName=="OneFinger")
                SceneManager.LoadScene("Onefinger");
                //Application.LoadLevel("Onefinger");
			else if (levelName=="TwoFinger")		
                //Application.LoadLevel("TwoFinger");
                SceneManager.LoadScene("TwoFinger");
			else if (levelName=="MultipleFinger")		
                //Application.LoadLevel("MultipleFingers");
	            SceneManager.LoadScene("MultipleFingers");
			else if (levelName=="MultiLayer")
                //Application.LoadLevel("MultiLayers");
                SceneManager.LoadScene("MultiLayers");
			else if (levelName=="GameController")
                //Application.LoadLevel("GameController");
                SceneManager.LoadScene("GameController");
			else if (levelName=="FreeCamera")
                //Application.LoadLevel("FreeCam");	
		        SceneManager.LoadScene("FreeCam");
			else if (levelName=="ImageManipulation")
                //Application.LoadLevel("ManipulationImage");
                SceneManager.LoadScene("ManipulationImage");
			else if (levelName=="Joystick1")
                //Application.LoadLevel("FirstPerson-DirectMode-DoubleJoystick");	
	            SceneManager.LoadScene("FirstPerson-DirectMode-DoubleJoystick");
			else if (levelName=="Joystick2")
                //Application.LoadLevel("ThirdPerson-DirectEventMode-DoubleJoystick");
                SceneManager.LoadScene("ThirdPerson-DirectEventMode-DoubleJoystick");
			else if (levelName=="Button")
                //Application.LoadLevel("ButtonExample");	
		        SceneManager.LoadScene("GameController");
			else if (levelName=="Exit")
				Application.Quit();						
		}
		
	}
}
