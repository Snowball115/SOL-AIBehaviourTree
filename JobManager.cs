using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobManager : MonoBehaviour
{
    private IEnumerator mainTask;
    private List<Job> cachedJobs;
    private bool isActive;

    private void Awake()
    {
        cachedJobs = new List<Job>();
    }

    private void Start()
    {
        //StartManager();
    }

    public void StartManager()
    {
        mainTask = Loop();
        StartCoroutine(mainTask);
    }

    public void StopManager()
    {
        StopCoroutine(mainTask);
        mainTask = null;
    }

    public void AddJob(Job job)
    {
        cachedJobs.Add(job);
    }

    public void PauseJob(Job job)
    {
        job.State = JobState.PAUSED;
    }

    public void ContinueJob(Job job)
    {
        job.State = JobState.ACTIVE;
    }

    private IEnumerator Loop()
    {
        Debug.Log("<color=#00cc00>[JobManager]</color> Manager started");
        
        bool isActive = true;

        while (isActive)
        {
            while (cachedJobs.Count > 0)
            {
                Job job = cachedJobs[0];

                if (job.isRunning)
                {
                    yield return null;
                }

                StartCoroutine(HandleJob(job));

                if (job.ReState == ReturnState.SUCCESS || job.ReState == ReturnState.FAILED)
                {
                    cachedJobs.RemoveAt(0);
                }
            }
            yield return null;
        }

        Debug.Log("<color=#00cc00>[JobManager]</color> Manager closed");
    }

    private IEnumerator HandleJob(Job job)
    {
        Debug.Log("<color=yellow>Task started</color>");

        isActive = true;
        job.isRunning = true;

        while (isActive && job != null)
        {
            if (job.CodeAdress.MoveNext())
            {
                if (job.State == JobState.PAUSED)
                {
                    yield return null;
                }
                else if (job.State == JobState.ACTIVE || job.State == JobState.PENDING)
                {
                    yield return job.CodeAdress.Current;
                }
            }
            else
            {
                isActive = false;
                job.isRunning = false;
                job.ReState = ReturnState.SUCCESS;
                Debug.Log("<color=green>Task successful</color>");
                yield return null;
            }
            Debug.Log("Task finished");
        }
    }
}
