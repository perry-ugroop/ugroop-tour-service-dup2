using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Ugroop.API.SQL;
using Swashbuckle.Application;
using Swashbuckle.Swagger;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Ugroop.API.SQL {
    public class SwaggerConfig {
        public static void Register() {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c => {
                    c.SingleApiVersion("v1", "Tour API");

                    c.ApiKey("AccessToken")
                        .Description("Type bearer token here")
                        .Name("Authorization")
                        .In("header");


                    // Set this flag to omit descriptions for any actions decorated with the Obsolete attribute
                    //c.IgnoreObsoleteActions();

                    // Each operation be assigned one or more tags which are then used by consumers for various reasons.
                    // For example, the swagger-ui groups operations according to the first tag of each operation.
                    // By default, this will be controller name but you can use the "GroupActionsBy" option to
                    // override with any value.
                    //
                    //c.GroupActionsBy(apiDesc => apiDesc.HttpMethod.ToString());

                    // You can also specify a custom sort order for groups (as defined by "GroupActionsBy") to dictate
                    // the order in which operations are listed. For example, if the default grouping is in place
                    // (controller name) and you specify a descending alphabetic sort order, then actions from a
                    // ProductsController will be listed before those from a CustomersController. This is typically
                    // used to customize the order of groupings in the swagger-ui.
                    //
                    //c.OrderActionGroupsBy(new DescendingAlphabeticComparer());

                    // If you annotate Controllers and API Types with
                    // Xml comments (http://msdn.microsoft.com/en-us/library/b2s063f7(v=vs.110).aspx), you can incorporate
                    // those comments into the generated docs and UI. You can enable this by providing the path to one or
                    // more Xml comment files.
                    //
                    c.IncludeXmlComments(GetXmlCommentsPath());


                    // Swashbuckle makes a best attempt at generating Swagger compliant JSON schemas for the various types
                    // exposed in your API. However, there may be occasions when more control of the output is needed.
                    // This is supported through the "MapType" and "SchemaFilter" options:
                    //
                    // Use the "MapType" option to override the Schema generation for a specific type.
                    // It should be noted that the resulting Schema will be placed "inline" for any applicable Operations.
                    // While Swagger 2.0 supports inline definitions for "all" Schema types, the swagger-ui tool does not.
                    // It expects "complex" Schemas to be defined separately and referenced. For this reason, you should only
                    // use the "MapType" option when the resulting Schema is a primitive or array type. If you need to alter a
                    // complex Schema, use a Schema filter.
                    //
                    //c.MapType<ProductType>(() => new Schema { type = "integer", format = "int32" });

                    // If you want to post-modify "complex" Schemas once they've been generated, across the board or for a
                    // specific type, you can wire up one or more Schema filters.
                    //
                    //c.SchemaFilter<ApplySchemaVendorExtensions>();

                    // In a Swagger 2.0 document, complex types are typically declared globally and referenced by unique
                    // Schema Id. By default, Swashbuckle does NOT use the full type name in Schema Ids. In most cases, this
                    // works well because it prevents the "implementation detail" of type namespaces from leaking into your
                    // Swagger docs and UI. However, if you have multiple types in your API with the same class name, you'll
                    // need to opt out of this behavior to avoid Schema Id conflicts.
                    //
                    //c.UseFullTypeNameInSchemaIds();

                    // Alternatively, you can provide your own custom strategy for inferring SchemaId's for
                    // describing "complex" types in your API.
                    //  
                    //c.SchemaId(t => t.FullName.Contains('`') ? t.FullName.Substring(0, t.FullName.IndexOf('`')) : t.FullName);

                    // Set this flag to omit schema property descriptions for any type properties decorated with the
                    // Obsolete attribute 
                    //c.IgnoreObsoleteProperties();

                    // In accordance with the built in JsonSerializer, Swashbuckle will, by default, describe enums as integers.
                    // You can change the serializer behavior by configuring the StringToEnumConverter globally or for a given
                    // enum type. Swashbuckle will honor this change out-of-the-box. However, if you use a different
                    // approach to serialize enums as strings, you can also force Swashbuckle to describe them as strings.
                    // 
                    //c.DescribeAllEnumsAsStrings();

                    // Similar to Schema filters, Swashbuckle also supports Operation and Document filters:
                    //
                    // Post-modify Operation descriptions once they've been generated by wiring up one or more
                    // Operation filters.
                    //
                    //c.OperationFilter<AddDefaultResponse>();
                    //
                    // If you've defined an OAuth2 flow as described above, you could use a custom filter
                    // to inspect some attribute on each action and infer which (if any) OAuth2 scopes are required
                    // to execute the operation
                    //
                    //c.OperationFilter<AssignOAuth2SecurityRequirements>();

                    //c.OperationFilter<MultipleOperationsWithSameVerbFilter>();
                    //c.OperationFilter<ParameterFilter>();
                    c.OperationFilter<ExamplesOperationFilter>();

                    // Post-modify the entire Swagger document by wiring up one or more Document filters.
                    // This gives full control to modify the final SwaggerDocument. You should have a good understanding of
                    // the Swagger 2.0 spec. - https://github.com/swagger-api/swagger-spec/blob/master/versions/2.0.md
                    // before using this option.
                    //
                    //c.DocumentFilter<ApplyDocumentVendorExtensions>();

                    // In contrast to WebApi, Swagger 2.0 does not include the query string component when mapping a URL
                    // to an action. As a result, Swashbuckle will raise an exception if it encounters multiple actions
                    // with the same path (sans query string) and HTTP method. You can workaround this by providing a
                    // custom strategy to pick a winner or merge the descriptions for the purposes of the Swagger docs 
                    //
                    //c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                    // Wrap the default SwaggerGenerator with additional behavior (e.g. caching) or provide an
                    // alternative implementation for ISwaggerProvider with the CustomProvider option.
                    //
                    //c.CustomProvider((defaultProvider) => new CachingSwaggerProvider(defaultProvider));
                })
                .EnableSwaggerUi(c => {
                    // Enable this code to implement the StormPath access token validation

                    c.InjectJavaScript(thisAssembly, "Ugroop.API.SQL.Swagger.SwaggerUiCustomization.js");
                    c.EnableApiKeySupport("Authorization", "header");


                    // Use this option to control how the Operation listing is displayed.
                    // It can be set to "None" (default), "List" (shows operations for each resource),
                    // or "Full" (fully expanded: shows operations and their details).
                    //
                    //c.DocExpansion(DocExpansion.List);

                    // Specify which HTTP operations will have the 'Try it out!' option. An empty paramter list disables
                    // it for all operations.
                    //
                    //c.SupportedSubmitMethods("GET", "HEAD");

                });
        }

        protected static string GetXmlCommentsPath() {
            return Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, "bin", "Ugroop.API.SQL.XML");
        }
    }

    public class MultipleOperationsWithSameVerbFilter : IOperationFilter {
        public void Apply(
            Operation operation,
            SchemaRegistry schemaRegistry,
            ApiDescription apiDescription) {
            if (operation.parameters != null) {
                operation.operationId += "By";
                foreach (var parm in operation.parameters) {
                    operation.operationId += string.Format("{0}", parm.name);
                }
            }
        }
    }

    public class ParameterFilter : IOperationFilter {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription) {
            if (operation.parameters == null) {
                return;
            }

            foreach (var parameter in operation.parameters
                .Where(x => x.@in == "query" && x.name.Contains("."))) {
                parameter.name = Regex.Replace(parameter.name,
                    @"^ # Match start of string
                .*? # Lazily match any character, trying to stop when the next condition becomes true
                \.  # Match the dot", "", RegexOptions.IgnorePatternWhitespace);
            }
        }
    }

    public class SwaggerResponseExamplesAttribute : Attribute {
        public SwaggerResponseExamplesAttribute(Type responseType, Type examplesType) {
            ResponseType = responseType;
            ExamplesType = examplesType;
        }

        public Type ResponseType { get; set; }
        public Type ExamplesType { get; set; }
    }

    public interface IProvideExamples {
        object GetExamples();
    }

    public class ExamplesOperationFilter : IOperationFilter {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription) {
            var responseAttributes = apiDescription.GetControllerAndActionAttributes<SwaggerResponseExamplesAttribute>();

            foreach (var attr in responseAttributes) {
                var schema = schemaRegistry.GetOrRegister(attr.ResponseType);

                var response = operation.responses.FirstOrDefault(x => x.Value.schema.type == schema.type && x.Value.schema.@ref == schema.@ref).Value;

                if (response != null) {
                    var provider = (IProvideExamples)Activator.CreateInstance(attr.ExamplesType);
                    response.examples = FormatAsJson(provider);
                }
            }
        }

        private static object FormatAsJson(IProvideExamples provider) {
            var examples = new Dictionary<string, object>()
            {
            {
                "application/json", provider.GetExamples()
            }
        };

            return ConvertToCamelCase(examples);
        }

        private static object ConvertToCamelCase(Dictionary<string, object> examples) {
            var jsonString = JsonConvert.SerializeObject(examples, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            return JsonConvert.DeserializeObject(jsonString);
        }
    }

}
