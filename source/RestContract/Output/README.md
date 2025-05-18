**To generate models and controllers based on the OpenAPI specification, you need to navigate to the ./source/ directory**

Generate:
``
openapi-generator-cli generate -g aspnetcore -i ./RestContract/Output/Specification/FastCodeAPI.json -o ./Presentation  --additional-properties=operationResultTask=true,packageName=Presentation,useSeparateModelProject=true
``