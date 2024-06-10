namespace serverless_temps.Models;
public class TemperatureLog{
    public TemperatureLog(string deviceId, double tempF, DateTime observedTimeStamp){
        DeviceId = deviceId;
        TempF = tempF;
        ObservedTimeStamp = observedTimeStamp;
    }

    public string DeviceId { get; }
    public double TempF { get; }
    public DateTime ObservedTimeStamp { get;}


}