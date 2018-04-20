using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ShaderChange : MonoBehaviour {

	public Shader shader1;
	public Shader shader2;
	private Renderer holoRenderer;

	SerialPort sp; //whatever COM arduino uses

	private void Awake()
	{
		try
		{
			sp = new SerialPort("COM4", 9600);
		}
		catch(System.Exception )
		{

		}
	}

	void Start()
	{

		holoRenderer = GetComponent<Renderer>();
		
		try
		{
			sp.Open();
			sp.ReadTimeout = 1;
		}
		catch(System.Exception)
		{

		}

	}

	// Update is called once per frame
	void Update () {
		
		if (sp.IsOpen)
		{
			
			try
			{
				 // DO WHATEVER THE *YOU WANT
				if(sp.ReadByte() == 1)
				{
					if(holoRenderer.material.shader == shader1)
					{
						Debug.Log("Changing shader to shader 2");
						holoRenderer.material.shader = shader2;
					} else
					{
						Debug.Log("Changing shader to shader 1");
						holoRenderer.material.shader = shader1;
					}
				
				}

			}
			catch (System.Exception)
			{
				
			}
		}
		else
		{
			if(Input.GetKeyDown(KeyCode.R))
			{
				//Do something
				Debug.Log("lee alterno");
			}
		}
	}




}