# Bid-Calculation-Tool

## Dedicated to calculating fees for a vehicle seller project.

- This app is completely dedicated to the calculation of the total prices for a car after adding fees and additional costs in a friendly manner that lets the customer get this data in an easier and faster way.

## Table of Contents

- [Definition](#definition)
- [Installation](#installation)

## Definition

The following is an image of the relational diagram for the current database design.

![relational diagram](/Progi%20Relational.png)

## Installation

At the moment, the installation steps for this project are the following: 
1. Install docker.
2. Run the command  ```docker compose up -d```
    - This command executes the docker-compose.yaml file and creates the mysql db with a bind mount on ./progidb folder and run a dotnet api.
