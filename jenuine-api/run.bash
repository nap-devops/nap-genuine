#!/bin/bash

source .env
export basicAuthen__keycloak__credentials__secret=${OIDC_CLIENT_SECRET}

dotnet run
