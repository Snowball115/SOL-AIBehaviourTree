using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Job
{
    public IEnumerator CodeAdress { get; set; }
    public JobState State { get; set; }
    public ReturnState ReState { get; set; }
    public List<Job> SubJobs { get; set; }
    public bool isRunning { get; set; }

    public Job(IEnumerator codeAdress, JobState state)
    {
        CodeAdress = codeAdress;
        State = state;
        SubJobs = new List<Job>();
    }

    public void AddSubJob(Job job)
    {
        SubJobs.Add(job);
    }
}

public enum JobState
{
    NULL = -1,
    NONE = 0,
    ACTIVE = 1,
    PAUSED = 2,
    PENDING = 3
}

public enum ReturnState
{
    NULL = -1,
    NONE = 0,
    SUCCESS = 1,
    FAILED = 2
}
