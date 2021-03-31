// <copyright file="Program.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using CommandLine;

namespace Examples.Console
{
    /// <summary>
    /// Main samples entry point.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method - invoke this using command line.
        /// For example:
        ///
        /// dotnet run -p Examples.Console.csproj console
        /// dotnet run -p Examples.Console.csproj inmemory
        /// dotnet run -p Examples.Console.csproj zipkin -u http://localhost:9411/api/v2/spans
        /// dotnet run -p Examples.Console.csproj jaeger -h localhost -p 6831
        /// dotnet run -p Examples.Console.csproj prometheus -i 15 -p 9184 -d 2
        /// dotnet run -p Examples.Console.csproj otlp -e "http://localhost:4317"
        /// dotnet run -p Examples.Console.csproj zpages
        ///
        /// The above must be run from the project root folder
        /// (eg: C:\repos\opentelemetry-dotnet\examples\Console\).
        /// </summary>
        /// <param name="args">Arguments from command line.</param>
        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<OtlpOptions>(args)
                .MapResult(
                    (OtlpOptions options) => TestOtlpExporter.Run(options.Endpoint),
                    errs => 1);

            System.Console.ReadLine();
        }
    }

#pragma warning disable SA1402 // File may only contain a single type


    [Verb("otlp", HelpText = "Specify the options required to test OpenTelemetry Protocol (OTLP)")]
    internal class OtlpOptions
    {
        //[Option('e', "endpoint", HelpText = "Target to which the exporter is going to send traces or metrics", Default = "http://localhost:4317")]
        // [Option('e', "endpoint", HelpText = "Target to which the exporter is going to send traces or metrics", Default = "http://otel.localhost.openiap.io:80")]
        [Option('e', "endpoint", HelpText = "Target to which the exporter is going to send traces or metrics", Default = "https://otel.localhost.openiap.io:443")]
        public string Endpoint { get; set; }
    }

#pragma warning restore SA1402 // File may only contain a single type

}
