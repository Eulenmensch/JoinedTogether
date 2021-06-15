using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Obi;
using UnityEngine;

namespace UnityTemplateProjects
{
	public class GoalPost : MonoBehaviour
	{
		[SerializeField] private float winTime;
		private Coroutine winTimerRoutine;

		private ObiSolver solver;
		private Obi.ObiList<Oni.Contact> lastContacts;
		private bool timerRunning;

		private void Awake()
		{
			solver = GetComponent<ObiSolver>();
			lastContacts = new ObiList<Oni.Contact>();
		}

		private void OnEnable()
		{
			solver.OnCollision += OnObiCollision;
		}

		private void OnDisable()
		{
			solver.OnCollision -= OnObiCollision;
		}

		void OnObiCollision(object sender, Obi.ObiSolver.ObiCollisionEventArgs e)
		{
			var contacts = e.contacts;
			foreach (var contact in contacts)
			{
				if (ObiColliderWorld.GetInstance().colliderHandles[contact.bodyB].owner.gameObject.CompareTag("Goal") && !timerRunning)
				{
					Debug.Log("Goal Enter");
					winTimerRoutine = StartCoroutine(WinTimer());
					timerRunning = true;
				}
			}
			//if the goal object is not contained in the except, it is still colliding.
			//if it stops colliding, it will not be in contacts but in lastcontacts, thus
			//included in the except result.
			var result = lastContacts.Except(contacts);
			foreach (var contact in result)
			{
				if (ObiColliderWorld.GetInstance().colliderHandles[contact.bodyB].owner.gameObject.CompareTag("Goal"))
				{
					Debug.Log("Goal Exit");
					if(winTimerRoutine != null)
					{
						StopCoroutine(winTimerRoutine);
						timerRunning = false;
					}
				}
			}
			lastContacts = e.contacts;
		}

		private IEnumerator WinTimer()
		{
			var startTime = Time.time;
			while (Time.time - startTime <= winTime)
			{
				yield return null;
			}

			GameManager.Instance.LevelWon();
		}
	}
}