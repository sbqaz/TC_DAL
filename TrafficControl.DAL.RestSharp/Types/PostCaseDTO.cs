namespace TrafficControl.DAL.RestSharp
{
    public class PostCaseDTO 
    {
        public string ErrorDescription { get; set; }
        public long Installation { get; set; }
        public ObserverSelection Observer { get; set; }
    }
}