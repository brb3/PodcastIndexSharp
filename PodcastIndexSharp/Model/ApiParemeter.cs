namespace PodcastIndexSharp.Model
{
    /// <summary>
    /// Stores information about a parameter to be sent to the API.
    /// </summary>
    public class ApiParameter
    {
        public string Name { get; set; }

        public object? Value { get; set; }

        public ApiParameter(string name, object? value)
        {
            Name = name;
            Value = value;
        }
    }
}