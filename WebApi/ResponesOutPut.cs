namespace WebApi
{
    public class ResponesOutPut
    {
        private ResponesOutPut(object _Data , ResponseStatus _Status, string _StatusDescription)
        {
            Data = _Data ;
            Status = _Status ;
            StatusDescription = _StatusDescription ;
        }
        public object Data {  get; set; }
        public ResponseStatus Status {  get; set; }
        public string StatusDescription {  get; set; }
        public static ResponesOutPut Create(object data, ResponseStatus status, string statusdescription)
    => new ResponesOutPut(data, status, statusdescription);


    }
    public enum ResponseStatus
    {
        Success = 1,
        Error = 2,
        Warning = 3,
        BadRequest = 4
    }
}