using System;


namespace smart_local
{
    /// <summary>
    /// Main program
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// C# program to get SMART server with local web server
        /// </summary>
        /// <param name="fhirServerUrl">FHIR R4 end point url</param>
        /// <returns></returns>
        /// 
        private const string _defaultFhirServerUrl = "https://launch.smarthealthit.org/v/r4/sim/WzIsIiIsIjFjYjUxMTU3LTgwODMtNDEwZi04N2QxLTA3YTk0NjI5MjIyYSIsIkFVVE8iLDAsMCwwLCIiLCIiLCIiLCIiLCIiLCIiLCIiLDAsMV0/fhir/"; 
        static int Main(
            string fhirServerUrl
        ){

            if(string.IsNullOrEmpty(fhirServerUrl)) fhirServerUrl = _defaultFhirServerUrl;

            Console.WriteLine($"FHIR Server: {fhirServerUrl}");

            Hl7.Fhir.Rest.FhirClient fhirClient = new Hl7.Fhir.Rest.FhirClient(fhirServerUrl);

            if(!FhirUtils.TryGetSmartUrls(fhirClient, out string authorizeUrl, out string tokenUrl))
            {
                System.Console.WriteLine($"Failed to descover SMART URLs");
                return -1;
            }

            Console.WriteLine($"Authorize URLs: {authorizeUrl}");
            Console.WriteLine($"    Token URLs: {tokenUrl}");
            return 0;
        }
    }
}

