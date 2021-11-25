using System.Runtime.Serialization;

namespace Api.Models
{
    [DataContract]
    public class ReturnError
    {
        [DataMember]
        public string Message { get; set;}

        public ReturnError(string message)
        {
            Message = message;
        }
    }
}