**To generate models and controllers based on the OpenAPI specification, you need to navigate to the ./source/ directory**

Generate:
``
openapi-generator-cli generate -g aspnetcore -i ./FacilityAccessService.RestContract/Output/Specification/FacilityAccessService.json -o ./FacilityAccessService.RestService  --additional-properties=operationResultTask=true,packageName=FacilityAccessService.RestService,useSeparateModelProject=true
``