/*
	This script is placed in public domain. The author takes no responsibility for any possible harm.
	Contributed by Jonathan Czeck
*/
using UnityEngine;
using UnitySteer;
using UnitySteer.Vehicles;
using System.Collections;

public class LightningBolt : MonoBehaviour
{
	public WanderBehavior target;
	public int zigs = 100;
	public float speed = 1f;
	public float scale = 1f;
	public Light startLight;
	public Light endLight;
	
	Perlin noise;
	float oneOverZigs;
	
	private Particle[] particles;
	private Rope[] vehicles;
	
	void Start()
	{
		oneOverZigs = 1f / (float)zigs;
		particleEmitter.emit = false;

		particleEmitter.Emit(zigs);
		particles = particleEmitter.particles;
		vehicles = new Rope[particles.Length];
		RandomizeParticlePositions();

		for(int i = particles.Length - 1; i >= 0; i--)
		{
		    vehicles[i] = new Rope(particles[i].position, 0.1f, null, null);
		    
		    vehicles[i].Mass = 0.1f;
		    vehicles[i].Radius = 0.05f;
		    vehicles[i].MaxSpeed = 10f;
		    vehicles[i].MaxForce =  5;

            if (i < particles.Length - 1)
            {
		        vehicles[i].Next = vehicles[i+1];
		        vehicles[i+1].Previous = vehicles[i];
            }
            else
            {
		        vehicles[i].Next = target.Wanderer;
            }
		    
		}
	}
	
	void Update ()
	{
	    //RandomizeParticlePositions(false);

		for(int i = particles.Length - 1; i >= 0; i--)
		{
		    vehicles[i].Position = particles[i].position;
		    vehicles[i].update(Time.time, Time.deltaTime);
		    particles[i].position = vehicles[i].Position;
		}
		
		particleEmitter.particles = particles;
		
		if (particleEmitter.particleCount >= 2)
		{
			if (startLight)
				startLight.transform.position = particles[0].position;
			if (endLight)
				endLight.transform.position = particles[particles.Length - 1].position;
		}
	}	
	
	void RandomizeParticlePositions()
	{
	    RandomizeParticlePositions(0, false);
	}
	
	void RandomizeParticlePositions(int startIndex)
	{
	    RandomizeParticlePositions(startIndex, false);
	}

	void RandomizeParticlePositions(bool isOffset)
	{
	    RandomizeParticlePositions(0, isOffset);
	}
	
	void RandomizeParticlePositions(int startIndex, bool isOffset)
	{
		if (noise == null)
			noise = new Perlin();
			
		float timex = Time.time * speed * 0.1365143f;
		float timey = Time.time * speed * 1.21688f;
		float timez = Time.time * speed * 2.5564f;
		/*
		float timey = Time.time * speed * 0.21688f;
		float timez = Time.time * speed * 0.2564f;
		*/
		
		for (int i = startIndex; i < particles.Length; i++)
		{
		    Vector3 position = isOffset ? particles[i].position
		                            : Vector3.Lerp(transform.position, target.Wanderer.Position, oneOverZigs * (float)i);
			Vector3 offset = new Vector3(noise.Noise(timex + position.x, timex + position.y, timex + position.z),
										noise.Noise(timey + position.x, timey + position.y, timey + position.z),
										noise.Noise(timez + position.x, timez + position.y, timez + position.z));
			position += (offset * scale * ((float)i * oneOverZigs));
			
			particles[i].position = position;
			particles[i].color = Color.white;
			particles[i].energy = 1f;
			// Debug.Log("new pos for "+i+" "+position);
		}
	}
}