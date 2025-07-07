namespace TestWebApi.Notes
{
    public class Notes
    {
        /*
        What is asp.net web api?
        - Asp.net web api is a framework for building HTTP based services, built on top of .Net framework.
        these services can be consumed by broad range of clients like desktop app, mobile app, websites and IOTs

        REST Constrains
        * Server Client - Client sends a request and server sends a response.
        * Stateless - The communication between client and server must be stateless, It means
                        that the server shouldn't be storing anything about the client on the server.
                        The request from the client should contain all the necessary information to 
                        process the request. this ensures that each request can be independently 
                        proceesed by the server

        * Cacheable - Responses must say whether they can be cached or not.
        * Uniform Interface - Use a consistent, predictable way to access resources which Makes 
                                  it easier to understand and use.
                        Key principles: Resources identified by URLs (e.g., /users/123)
                        Use standard HTTP methods (GET, POST, PUT, DELETE)
                        Use consistent formats (like JSON)

        Difference between launchsettings.json and appsettings.json
        * launchsettings - This file is development-only and controls how your application launches during development 
            and contains Environment variables - Set during development 
            (like ASPNETCORE_ENVIRONMENT=Development) ,URLs and ports, Browser settings -
            Whether to launch a browser automatically
        * appsettings - This file contains application configuration that your app 
                           actually uses at runtime. Connection strings - Database connections,
                            API keys and secrets, Application settings.
        The key distinction is that launchsettings.json is about how to run your app during 
        development, while appsettings.json is about what your app does when it runs.

        What is an assembly
        - An assembly is the compiled output of your .NET code — either a .DLL or .EXE file — that 
        the .NET runtime can load and execute.
        When you build your project, all your .cs files (controllers, services, models, 
        whatever you wrote) get compiled into a single DLL — like MyApi.dll.
        Your project depends on libraries you get via NuGet (like JSON serializers, Entity Framework, 
        Swagger, etc.). Each of those libraries comes as its own DLL file.

        Why there isn't any main method in program.cs file;
        - In lastest version of .Net core web api we dont mannually need to add main method in 
        program.cs file, the compiler generates it behind the scenes.


        Difference between controllerbase and controller class
        - controllerbase class have access to the model state, the current user and common methods
        for returning response while controller have some common helper 
        methods when returning views.

        what is UseRouting() and UseEndpoints middleware?
        - This is the middleware that sets up endpoint routing. It basically tells ASP.NET Core
        where this request is supposed to go. Match the incoming URL to an endpoint.
        UseEndpoints() is the middleware that actually executes the matched endpoint 
        that UseRouting() found.

        what is a Pipeline?
        - The entire chain of middleware that the request passes through from start ➡️ to finish.

        ActionResult
        - ActionResult is a class that acts as a flexible return type for controller actions. 
        It allows returning different kinds of HTTP responses using helper methods like Ok(), 
        NotFound(), BadRequest(), etc.

        -----------------------------------------------------------

        Services (Dependency) container
        - the services container in builder is the dependency container. so by adding services
        we can inject them whereever we want.

        ///
        .net CLI

        CLR

        ORM




        Difference between MVC and Web API
        - MVC returns the view along with the data but Web api is used return only data
        - MVC returns the data in Json only using JsonResult but the web api returns the data in various formats 
            like JSON, XML etc.
        - Web api includes various features such as model binding, routing etc, and are present in system.web.Http
            namespace and the MVC features are defined in system.web.MVC

         */
    }
}
