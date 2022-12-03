#!/bin/bash

curl --header "Content-Type: application/json" \
--request PUT \
-k -v \
--data '{"ProductId":"abc1234-modified", "ProductName":"name-0001-modified", "Description": "Seubpong modified"}' \
https://localhost:5001/api/products/org/napbiotec/action/UpdateProductById/638aa20602700ea99d812fb3
