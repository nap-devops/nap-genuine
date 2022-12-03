#!/bin/bash

HOST=localhost:5001
#HOST=api.genuine-dev.napbiotec.io

id=$(shuf -i 1-100000 -n 1)

#--request POST \

curl --header "Content-Type: application/json" \
-k -v \
--data "{\"ProductId\":\"abcxyz-hygkd-${id}\", \"ProductName\":\"name-0001-abc\", \"Description\": \"Seubpong Test BSON\"}" \
https://${HOST}/api/products/org/napbiotec/action/AddProduct/

#https://api.genuine-dev.napbiotec.io/api/products/org/napbiotec/action/AddProduct/

#https://localhost:5001/api/products/org/napbiotec/action/GetProducts
#https://api.genuine-dev.napbiotec.io/api/products/org/napbiotec/action/GetProducts