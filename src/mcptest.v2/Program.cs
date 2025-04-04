using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.Logging;
using ModelContextProtocol;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;

var config = new McpServerConfig
{
    Id = "everything",
    Name = "everything",
    TransportType = TransportTypes.StdIo,
    TransportOptions = new Dictionary<string, string>
    {
        // dotnet tool install --version 0.0.1-preview-04 --global mcpserver.everything.stdio
        { "command", "mcpserver.everything.stdio" }
    }
};

var options = new McpClientOptions
{
    ClientInfo = new() { Name = "everything-client", Version = "1.0.0" }
};

await using var client = await McpClientFactory.CreateAsync(config, options, null, LoggerFactory.Create(c => c.AddConsole()));
_ = await client.ListToolsAsync();