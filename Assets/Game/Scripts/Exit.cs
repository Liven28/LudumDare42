using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private Save scrSave;

	void Awake ()
    {
        scrSave = GetComponent<Save>();

        if (Application.isEditor == false)
        {
            Cursor.visible = false;
        }
    }

    void Update ()
    {
		if (Input.GetKeyDown (KeyCode.Escape))
        {
            if (Application.isEditor == false)
            {
                scrSave.FntSave();
                Application.Quit();
            }
        }
	}
}
