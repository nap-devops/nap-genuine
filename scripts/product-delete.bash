#!/bin/bash

curl --header "Content-Type: application/json" \
--request DELETE \
-k -v \
https://localhost:5001/api/products/org/napbiotec/action/DeleteProductById/638aa20602700ea99d812fb3/
