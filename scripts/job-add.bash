#!/bin/bash

HOST="james:ThisxIsPassw0rd@localhost:5001"
#HOST=api.genuine-dev.napbiotec.io

id=$(shuf -i 1-100000 -n 1)

#--request POST \

curl --header "Content-Type: application/json" \
-k -v \
--data "{\"JobId\":\"job-${id}\", \"Description\":\"Job xxx desc\", \"Type\": \"GenerateAssets\"}" \
https://${HOST}/api/jobs/org/napbiotec/action/AddJob

#https://api.genuine-dev.napbiotec.io/api/products/org/napbiotec/action/AddProduct/

#https://james:xxxxxxxx@localhost:5001/api/products/org/napbiotec/action/GetProducts
#https://api.genuine-dev.napbiotec.io/api/products/org/napbiotec/action/GetProducts