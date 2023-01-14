#!/bin/bash

. ./export.bash

#HOST="${USER_PASSWORD}@api.genuine-dev.napbiotec.io"

id=$(shuf -i 1-100000 -n 1)

#--request POST \

curl --header "Content-Type: application/json" \
-k -v \
--data "{\"ProductId\":\"abcxyz-hygkd-${id}\", \"RedirectUrl\": \"https://aldamex.com/register-product/result?status={0}&serial={1}&pin={2}\", \"ProductName\":\"name-0002-abc\", \"Description\": \"Seubpong Test BSON\"}" \
https://${HOST}/api/products/org/napbiotec/action/AddProduct

#https://api.genuine-dev.napbiotec.io/api/products/org/napbiotec/action/AddProduct/

#https://james:xxxxxxxx@localhost:5001/api/products/org/napbiotec/action/GetProducts
#https://api.genuine-dev.napbiotec.io/api/products/org/napbiotec/action/GetProducts