# Bid-Calculation-Tool

## Dedicated to calculating fees for a vehicle seller project.

- This app is completely dedicated to the calculation of the total prices for a car after adding fees and additional costs in a friendly manner that lets the customer get this data in an easier and faster way.

## Table of Contents

- [Design](#design)
- [Installation](#installation)
- [Tests](#tests)
- [What to change to be prod ready?](#prodModifications)

## Design

The following is an image of the relational diagram for the current database design.

![relational diagram](./Db/Progi%20Relational.png)

- This is a containerized app built with dotnet and mysql. 
- The images on which it is based are hosted on docker hub.

## Installation

At the moment, the installation steps for this project are the following: 
1. Install docker.
2. Run the command  ```docker compose up -d```
    - This command executes the docker-compose.yaml file and creates the mysql db with a bind mount on ./progidb folder and runs both a dotnet webapi and an angular frontend app.

## Tests
- Backend has tests which can be run by going to BidBack/BidCalculation/ and running ```dotnet test BidCalculation.Tests.csproj```
- Frontend has tests which can be run by going to BidFront/ and running ```ng test --karma-config=karma.conf.js```

## ProdModifications
Things to consider:
- Add CRUD operations for system to work in a better and more flexible manner.
- Add security layer such as jwt and/or cookies for session management.
- Add follow up module, including actions such as attaching detail to an email for the customer.
- Manage a better branching strategy.
- Add better testing files, such as postman collections.
- Better module management on the frontend.
- Better UX/UI design for engagement. 
- Improve service segregation in frontend.
- Better CORS management.
- Better module management.
- Add a pipeline procedure such as github actions to execute testing for CI/CD.

