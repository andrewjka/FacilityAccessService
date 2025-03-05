
# FacilityAccessService
## Navigation list
***

1. [About](#about)
2. [Project structure](#structure)
    - [Project relationships](#schema_whole_project)
    - [Project descriptions](#project_descriptions)

<a id="about"></a>
## About
***
This service realizes the system of access control to the facilities on the territory of the enterprise.

<a id="structure"></a>
## Project structure
***
In this section, each project within the solution is described, including its purpose and responsibilities.

<a id="schema_whole_project"></a>
### Project relationships
***
![The diagram of the relationship between the projects should have been here](./docs/images/schema_whole_project.jpg)

<a id="project_descriptions"></a>
### Project descriptions
***

**Business**

This project is responsible for business rules. As a rule, it does not reference anything and serves as a cornerstone for the rest of the system. It contains business entities, repository interfaces, service interfaces, and interfaces for service integrations.
***

**Business.Validation**

In my solution, which may not be entirely correct, business entities do not contain an internal validation mechanism. Instead, I have extracted validation rules for various business models and actions into a separate layer. All these rules are implemented using *FluentValidation*.
***

**Event**

This project includes components that could have also been part of the business project. Essentially, it is still the same business layer as Business and Business.Validation, but separated into different projects for convenience. It contains interfaces for event publishing and processing, as well as business event models.
***

**Persistence**

This project is positioned beyond the business layer and pertains to the infrastructure. It references the business layer and implements repository interfaces through interaction with a specific database.
***