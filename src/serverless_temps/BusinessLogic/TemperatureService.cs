namespace serverless_temps.BusinessLogic;

using serverless_temps.Models;

public interface ITemperatureService{
    Task<bool> LogCurrentTemperature(double temperature);
    Task<double> GetLatestTemperature();
    Task<List<TemperatureLog>> GetTemperatureHistory(int numObservations);

}

public class TemperatureService  : ITemperatureService{

   private readonly ILogger<TemperatureService> _logger;
   public TemperatureService(ILogger<TemperatureService> logger){
     _logger= logger;
   }

    public async Task<double> GetLatestTemperature()
    {
       var temperature = RandomNumberBetween(68,74);
        _logger.LogDebug("Observed temperature : {Temperature}",temperature.ToString("#.##"));
        return await Task.Run(()=> Math.Round(temperature, 2));
     
    }

    public async Task<List<TemperatureLog>> GetTemperatureHistory(int numObservations)
    {
        const int maxLimit = 1000;
        var limit = Math.Min(maxLimit, numObservations);

        var history = new List<TemperatureLog>();
        for(var i =0; i < limit; i++){
            var temperature = RandomNumberBetween(68,74);
            history.Add(new TemperatureLog("1", temperature, DateTime.UtcNow));
           
        }
         return await Task.Run(()=> history);
    }

    public Task<bool> LogCurrentTemperature(double temperature)
    {
        _logger.LogDebug("Observed temperature : {Temperature}",temperature.ToString("#.##"));
        return Task.Run(()=> true);
    }

    private static double RandomNumberBetween(double min, double max){
        var random = new Random();
        var next = random.NextDouble();
        return min + next * (max - min);
    }
}