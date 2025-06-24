using DemoRefit.Client.Refit;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddRefitClients(builder.Configuration);

await builder.Build().RunAsync();
