using Microsoft.AspNetCore.Mvc;
using serverless_temps.BusinessLogic;

[Route("api/[controller]")]
public class TemperatureController: ControllerBase {
    private readonly ITemperatureService _temperatureService;
    private readonly ILogger<TemperatureController> _logger;

    public TemperatureController(ILogger<TemperatureController> logger,
                                 ITemperatureService temperatureService){

            _logger = logger;
            _temperatureService = temperatureService;  
    }

    [HttpGet]
    public async Task<IResult> Get() 
    {
        var temps = await _temperatureService.GetLatestTemperature();
        return Results.Ok(temps);
    }

    [HttpGet("{numberObservations:int}")]
    public async Task<IResult> GetHistory(int numberObservations){
            var temps = await _temperatureService.GetTemperatureHistory(numberObservations);
            return Results.Ok(temps);
    }


    [HttpPost]
    public async Task<IResult> Post([FromBody] string observation){
        var temperature = double.Parse(observation);
        var result = await _temperatureService.LogCurrentTemperature(temperature);
        return Results.Ok(result);
    }


}