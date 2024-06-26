using System.Text.Json.Serialization;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;
using Amazon.Lambda.Annotations;
using Amazon.Lambda.Annotations.APIGateway;
using Amazon.Lambda.APIGatewayEvents;
using ServerlessNativeAOTExample;
using ServerlessNativeAOTExample.Models;
using ServerlessNativeAOTExample.Services.Interfaces;

[assembly: LambdaGlobalProperties(GenerateMain = true)]
[assembly: LambdaSerializer(typeof(SourceGeneratorLambdaJsonSerializer<LambdaFunctionJsonSerializerContext>))]

namespace ServerlessNativeAOTExample;

/// <summary>
/// This class is used to register the input event and return type for the FunctionHandler method with the System.Text.Json source generator.
/// There must be a JsonSerializable attribute for each type used as the input and return type or a runtime error will occur 
/// from the JSON serializer unable to find the serialization information for unknown types.
/// 
/// Request and response types used with Annotations library must also have a JsonSerializable for the type. The Annotations library will use the same
/// source generator serializer to use non-reflection based serialization. For example parameters with the [FromBody] or types returned using 
/// the HttpResults utility class.
/// </summary>
[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(List<StringModel>))]
[JsonSerializable(typeof(APIGatewayHttpApiV2ProxyRequest))]
[JsonSerializable(typeof(APIGatewayHttpApiV2ProxyResponse))]
public partial class LambdaFunctionJsonSerializerContext : JsonSerializerContext
{
    // By using this partial class derived from JsonSerializerContext, we can generate reflection free JSON Serializer code at compile time
    // which can deserialize our class and properties. However, we must attribute this class to tell it what types to generate serialization code for.
    // See https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-source-generation
}

public class Functions
{
    private readonly IStringManipulator _stringService;
    public Functions(IStringManipulator stringService)
    {
        _stringService = stringService;
    }

    [LambdaFunction(MemorySize = 128, Timeout = 10)]
    [HttpApi(LambdaHttpMethod.Get, "/UpperStrings/{string1}/{string2}")]
    public  List<StringModel> UpperStrings(string string1, string string2, ILambdaContext context)
    {
        var UpperStrings =_stringService.toUpper(string1, string2);
        return UpperStrings;
    }

    [LambdaFunction(MemorySize = 128, Timeout = 10)]
    [HttpApi(LambdaHttpMethod.Get, "/LowerStrings/{string1}/{string2}")]
    public  List<StringModel> LowerStrings(string string1, string string2, ILambdaContext context)
    {
        var LowerStrings =_stringService.toLower(string1, string2);
        return LowerStrings;
    }
}