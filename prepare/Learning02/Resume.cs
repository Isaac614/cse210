public class Resume
{
    public string _name;
    public List<Job> _jobList = new List<Job>();


    public void Display()
    {
        Console.WriteLine(_name);
        foreach (Job job in _jobList)
        {
            job.DisplayJobDetails();
        }
    }
}