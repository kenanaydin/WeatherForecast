# Weather Forecast API using Onion Architecture 

A web api project that includes API services that forecast data could be entered and viewed as user friendly.
I have used technologies below in this project

# Built With

* [ASP.NET Core Web API](https://docs.microsoft.com/tr-tr/aspnet/core/web-api/?view=aspnetcore-5.0)
* [CQRS](https://martinfowler.com/bliki/CQRS.html#:~:text=CQRS%20stands%20for%20Command%20Query,you%20use%20to%20read%20information.)
* [MediatR](https://codeopinion.com/why-use-mediatr-3-reasons-why-and-1-reason-not/)
* [Docker](https://www.docker.com/)
* [Swagger](https://swagger.io/)
* [Unit Testing with Moq](https://softchris.github.io/pages/dotnet-moq.html#references)

# Installation

1. Clone the repo
   ```sh
   git clone https://github.com/kenanaydin/WeatherForecast.git
   ```
2. Go to the project location
   ```sh
   cd WeatherForecast
   ```
3. Run the docker compose command here
   ```sh
   docker compose up
   ```

# Usage

  You can get the Postman collection to test them by importing the exported collection. Please use below URL to download Postman collection; 

  https://1drv.ms/u/s!Am8gpEDceP3GkEviZkoS8nMPfsVy?e=ryjVCU

  You can also go to the swagger page on your browser after you run the application with docker compose up command

  http://localhost:5236/swagger/index.html
