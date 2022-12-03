#!/bin/bash

id=$(shuf -i 1-100000 -n 1)

#--request POST \

curl --header "Content-Type: application/json" \
-k -v \
--data "{\"ProductId\":\"abcxyz-hygkd-${id}\", \"ProductName\":\"name-0001-abc\", \"Description\": \"Seubpong Test BSON\"}" \
https://localhost:5001/api/products/org/napbiotec/action/AddProduct/
