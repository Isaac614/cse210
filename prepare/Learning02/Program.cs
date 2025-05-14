class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2000;
        job1._endYear = 2005;

        Job job2 = new Job();
        job2._jobTitle = "QA";
        job2._startYear = 2000;
        job2._endYear = 2010;

        Resume resume = new Resume();
        resume._name = "Isaac";
        resume._jobList.Add(job1);
        resume._jobList.Add(job2);

        resume.Display();
    }

}