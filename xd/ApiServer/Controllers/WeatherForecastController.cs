using Microsoft.AspNetCore.Mvc; // Importa el espacio de nombres para trabajar con controladores de MVC en ASP.NET Core.

namespace ApiServer.Controllers // Define un espacio de nombres para organizar las clases del controlador.
{
    [ApiController] // Indica que esta clase es un controlador API, habilitando funcionalidades adicionales.
    [Route("[controller]")] // Establece la ruta base para las solicitudes HTTP (ser� reemplazada por el nombre del controlador).
    public class WeatherForecastController : ControllerBase // Declara la clase del controlador que hereda de ControllerBase.
    {
        // Declara un array est�tico y de solo lectura que contiene descripciones del clima.
        private static readonly string[] Summaries = new[]
        {
            "Fai sol", // Resumen 1: Hace sol
            "Chove", // Resumen 2: Est� lloviendo
            "Fai fr�o", // Resumen 3: Hace fr�o
            "M�is fr�o", // Resumen 4: Hace m�s fr�o
            "Calor" // Resumen 5: Hace calor
        };

        private readonly ILogger<WeatherForecastController> _logger; // Declara un registrador para el controlador.

        // Constructor que recibe un logger para permitir la inyecci�n de dependencias.
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger; // Asigna el logger recibido al campo privado _logger.
        }

        [HttpGet(Name = "GetWeatherForecast")] // Indica que este m�todo maneja solicitudes HTTP GET y le asigna un nombre.
        public IEnumerable<WeatherForecast> Get() // M�todo p�blico que devuelve una colecci�n de WeatherForecast.
        {
            // Genera un rango de n�meros del 1 al 5 y para cada n�mero crea un nuevo WeatherForecast.
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)), // Establece la fecha como la fecha actual m�s 'index' d�as.
                TemperatureC = Random.Shared.Next(-20, 55), // Genera una temperatura aleatoria entre -20 y 55 grados Celsius.
                Summary = Summaries[Random.Shared.Next(Summaries.Length)] // Selecciona un resumen aleatorio del array Summaries.
            })
            .ToArray(); // Convierte la colecci�n de WeatherForecast en un array y lo devuelve.
        }
    }
}
