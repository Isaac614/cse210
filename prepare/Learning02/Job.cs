public class Job
    {
        public string _jobTitle;
        public int _startYear;
        public int _endYear;

        public void DisplayJobDetails()
        {
            Console.WriteLine(_jobTitle);
            Console.WriteLine(_startYear);
            Console.WriteLine(_endYear);
        }
    }